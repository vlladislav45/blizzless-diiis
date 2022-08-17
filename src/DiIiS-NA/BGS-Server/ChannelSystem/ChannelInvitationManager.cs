﻿//Blizzless Project 2022
//Blizzless Project 2022 
using bgs.protocol;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.AccountsSystem;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Base;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Battle;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Helpers;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Objects;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Linq;

namespace DiIiS_NA.LoginServer.ChannelSystem
{
	public class ChannelInvitationManager : RPCObject
	{
		public readonly Dictionary<ulong, bgs.protocol.Invitation> _onGoingInvitations = new Dictionary<ulong, bgs.protocol.Invitation>();
		public static Dictionary<ulong, bgs.protocol.Invitation> GoingInvitations = new Dictionary<ulong, bgs.protocol.Invitation>();

		public static ulong InvitationIdCounter = 1;

		public ChannelInvitationManager()
		{
			// TODO: Hardcoded 1 as channel persistent id in this case...
			
			this.BnetEntityId = bgs.protocol.EntityId.CreateBuilder().SetHigh((ulong)EntityIdHelper.HighIdType.ChannelId).SetLow(10000000000).Build();
		}

		public bgs.protocol.Invitation GetInvitationById(ulong Id)
		{

			if (!this._onGoingInvitations.ContainsKey(Id))
			{
				foreach (var inv in _onGoingInvitations.Values)
					if (inv.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId.Low == Id)
						return inv;
				return null;
			}

			else
				return this._onGoingInvitations[Id];
		}

		public void ClearInvitations()
		{
			this._onGoingInvitations.Clear();
		}

		public void HandleInvitation(BattleClient client, bgs.protocol.Invitation invitation)
		{
			var invitee = this.Subscribers.FirstOrDefault(subscriber => subscriber.Key.Account.GameAccount.BnetEntityId.Low == invitation.InviteeIdentity.GameAccountId.Low).Key;
			if (invitee == null) return;

			this._onGoingInvitations.Add(invitation.Id, invitation);
			GoingInvitations.Add(invitation.Id, invitation);

			var notification = bgs.protocol.channel.v1.InvitationAddedNotification.CreateBuilder().SetInvitation(invitation);

			invitee.MakeTargetedRPC(this, (lid) =>
				bgs.protocol.channel.v1.ChannelInvitationListener.CreateStub(invitee).OnReceivedInvitationAdded(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));
		}

		public Channel HandleAccept(BattleClient client, bgs.protocol.channel.v1.AcceptInvitationRequest request)
		{
			Invitation invitation = null;
			if (!this._onGoingInvitations.ContainsKey(request.InvitationId))
			{
				foreach (var inv in _onGoingInvitations.Values)
					if(inv.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId.Low == request.InvitationId)
						invitation = inv;

				if(invitation == null)
					return null;
			}

			if (invitation == null)
				invitation = this._onGoingInvitations[request.InvitationId];
			
			var channel = ChannelManager.GetChannelByEntityId(invitation.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId);

			var notification = bgs.protocol.channel.v1.InvitationRemovedNotification.CreateBuilder().SetInvitation(invitation.ToBuilder()).SetReason((uint)InvitationRemoveReason.Accepted);
			this._onGoingInvitations.Remove(invitation.Id);
			GoingInvitations.Remove(request.InvitationId);

			client.MakeTargetedRPC(this, (lid) =>
				bgs.protocol.channel.v1.ChannelInvitationListener.CreateStub(client).OnReceivedInvitationRemoved(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));

			channel.Join(client, request.ObjectId); 

			var stateNotification = bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder()
				.SetAgentId(bgs.protocol.EntityId.CreateBuilder().SetHigh(0).SetLow(0).Build())
				.SetStateChange(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation).SetReason(0).Build())
				.Build();

			foreach (var member in channel.Members.Keys)
			{
				member.MakeTargetedRPC(channel, (lid) =>
					bgs.protocol.channel.v1.ChannelListener.CreateStub(member).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, stateNotification, callback => { }));
			}

			return channel;
		}

		public void HandleHardJoin(BattleClient client, bgs.protocol.channel.v1.AcceptInvitationRequest request)
		{
			if (!this._onGoingInvitations.ContainsKey(request.InvitationId)) return;

			var invitation = this._onGoingInvitations[request.InvitationId];
			var channel = ChannelManager.GetChannelByEntityId(invitation.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId);

			this._onGoingInvitations.Remove(invitation.Id);
			var a = GameAccountManager.GetAccountByPersistentID(invitation.InviteeIdentity.GameAccountId.Low);

			var JoinClient = a.LoggedInClient;



			#region
			string GAME_SERVER_IP = Program.GAMESERVERIP;
			if (GameServer.NATConfig.Instance.Enabled)
				GAME_SERVER_IP = Program.PUBLICGAMESERVERIP;
			uint GAME_SERVER_PORT = 2001;

			var member = bgs.protocol.account.v1.GameAccountHandle.CreateBuilder();
			member.SetId((uint)JoinClient.Account.GameAccount.BnetEntityId.Low).SetProgram(0x00004433).SetRegion(1);

			var notification = bgs.protocol.matchmaking.v1.MatchmakingResultNotification.CreateBuilder();
			var connectInfo = bgs.protocol.matchmaking.v1.ConnectInfo.CreateBuilder();
			connectInfo.SetAddress(bgs.protocol.Address.CreateBuilder().SetAddress_(GAME_SERVER_IP).SetPort(GAME_SERVER_PORT));
			connectInfo.AddAttribute(bgs.protocol.v2.Attribute.CreateBuilder().SetName("GameAccount").SetValue(bgs.protocol.v2.Variant.CreateBuilder().SetBlobValue(member.Build().ToByteString())));
			connectInfo.AddAttribute(bgs.protocol.v2.Attribute.CreateBuilder().SetName("Token").SetValue(bgs.protocol.v2.Variant.CreateBuilder().SetUintValue(0xEEF4364684EE186E))); // FIXME
			//connectInfo.AddAttribute(AttributeOfServer); // Настройки игры

			var gh = bgs.protocol.matchmaking.v1.GameHandle.CreateBuilder();
			gh.SetMatchmaker(bgs.protocol.matchmaking.v1.MatchmakerHandle.CreateBuilder()
								.SetId((uint)JoinClient.Account.GameAccount.BnetEntityId.Low)
								.SetAddr(bgs.protocol.matchmaking.v1.HostProxyPair.CreateBuilder()
											.SetHost(ProcessId.CreateBuilder().SetLabel(1250).SetEpoch(1499729350))
											.SetProxy(ProcessId.CreateBuilder().SetLabel(0xaa82dfd9).SetEpoch(1497363883))));
			gh.SetGameServer(bgs.protocol.matchmaking.v1.HostProxyPair.CreateBuilder()
								.SetHost(ProcessId.CreateBuilder().SetLabel(1277).SetEpoch(1499729371))
								.SetProxy(ProcessId.CreateBuilder().SetLabel(0xf511871c).SetEpoch(1497363865)));

			//var gameFound = JoinClient.GameChannel as GamesSystem.GameDescriptor;
			var gameFound = GamesSystem.GameFactoryManager.FindPlayerGame(client);
			//var clients = (from player in request.Options.PlayerList select GameAccountManager.GetAccountByPersistentID(player.GameAccount.Id) into gameAccount where gameFound != null select gameAccount.LoggedInClient).ToList();
			List<BattleClient> clients = new List<BattleClient>() { JoinClient };
			
			if (JoinClient.CurrentChannel != null)
			{
				var channelStatePermission = bgs.protocol.channel.v1.ChannelState.CreateBuilder()
				   .AddAttribute(bgs.protocol.Attribute.CreateBuilder()
				   .SetName("D3.Party.JoinPermissionPreviousToLock")
				   .SetValue(bgs.protocol.Variant.CreateBuilder().SetIntValue(1).Build())
				   .Build()).Build();

				var notificationPermission = bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder()
					.SetAgentId(JoinClient.Account.GameAccount.BnetEntityId)
					.SetStateChange(channelStatePermission)
					.Build();

				JoinClient.MakeTargetedRPC(JoinClient.CurrentChannel, (lid) =>
					bgs.protocol.channel.v1.ChannelListener.CreateStub(JoinClient).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, notificationPermission, callback => { }));
			}
			gameFound.StartGame(clients, gameFound.DynamicId);

			var notificationFound = bgs.protocol.notification.v1.Notification.CreateBuilder()
				.SetSenderId(client.Account.GameAccount.BnetEntityId)
				.SetTargetId(JoinClient.Account.GameAccount.BnetEntityId)
				.SetType("GO_ENTRY");
			var attrF = bgs.protocol.Attribute.CreateBuilder()
				.SetName("game_request_id")
				.SetValue(bgs.protocol.Variant.CreateBuilder().SetUintValue(gameFound.RequestId).Build());
			notificationFound.AddAttribute(attrF);

			JoinClient.MakeRPC((lid) =>
				bgs.protocol.notification.v1.NotificationListener.CreateStub(JoinClient).OnNotificationReceived(new HandlerController() { ListenerId = lid }, notificationFound.Build(), callback => { }));


			gh.SetGameInstanceId((uint)gameFound.BnetEntityId.Low);

			connectInfo.AddAttribute(bgs.protocol.v2.Attribute.CreateBuilder().SetName("SGameId").SetValue(bgs.protocol.v2.Variant.CreateBuilder().SetIntValue((long)gameFound.BnetEntityId.Low)));
			connectInfo.AddAttribute(bgs.protocol.v2.Attribute.CreateBuilder().SetName("SWorldId").SetValue(bgs.protocol.v2.Variant.CreateBuilder().SetIntValue((long)71150))); // FIXME

			notification.SetRequestId(bgs.protocol.matchmaking.v1.RequestId.CreateBuilder().SetId(0));
			notification.SetResult(0);
			notification.SetConnectInfo(connectInfo);
			notification.SetGameHandle(gh);

			System.Threading.Tasks.Task.Delay(2000).ContinueWith(delegate {
				JoinClient.MakeRPC((lid) => bgs.protocol.matchmaking.v1.GameRequestListener.CreateStub(JoinClient).OnMatchmakingResult(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));
			});
			#endregion

		}

		public static ulong FindInvAsForClient(BattleClient client)
		{
			foreach (var inv in GoingInvitations.Values)
				if (inv.InviteeIdentity.GameAccountId.Low == client.Account.GameAccount.BnetEntityId.Low)
					return inv.Id;

			return System.UInt64.MaxValue;
		}
		public static Channel AltConnectToJoin(BattleClient client, bgs.protocol.channel.v1.AcceptInvitationRequest request)
		{
			Invitation invitation = null;
			if (!GoingInvitations.ContainsKey(request.InvitationId))
			{
				foreach (var inv in GoingInvitations.Values)
					if (inv.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId.Low == request.InvitationId)
						invitation = inv;

				if (invitation == null)
					return null;
			}

			if (invitation == null)
				invitation = GoingInvitations[request.InvitationId];

			var channel = ChannelManager.GetChannelByEntityId(invitation.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId);

			var notification = bgs.protocol.channel.v1.InvitationRemovedNotification.CreateBuilder().SetInvitation(invitation.ToBuilder()).SetReason((uint)InvitationRemoveReason.Accepted);
			GoingInvitations.Remove(invitation.Id);

			//client.MakeTargetedRPC(this, (lid) =>bgs.protocol.channel.v1.ChannelInvitationListener.CreateStub(client).OnReceivedInvitationRemoved(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));

			channel.Join(client, request.ObjectId);

			var stateNotification = bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder()
				.SetAgentId(bgs.protocol.EntityId.CreateBuilder().SetHigh(0).SetLow(0).Build())
				.SetStateChange(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation).SetReason(0).Build())
				.Build();

			var joinstateNotification = bgs.protocol.channel.v1.JoinNotification.CreateBuilder()
				.SetChannelState(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation).SetReason(0).Build())
				.Build();

			foreach (var member in channel.Members.Keys)
			{
				member.MakeTargetedRPC(channel, (lid) =>
					bgs.protocol.channel.v1.ChannelListener.CreateStub(member).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, stateNotification, callback => { }));
				member.MakeTargetedRPC(channel, (lid) =>
					bgs.protocol.channel.v1.ChannelListener.CreateStub(member).OnJoin(new HandlerController() { ListenerId = lid }, joinstateNotification, callback => { }));
			}

			return channel;
		}


		public Channel HandleAcceptAnother(BattleClient client, bgs.protocol.channel.v1.AcceptInvitationRequest request)
		{
			if (!this._onGoingInvitations.ContainsKey(request.InvitationId)) return null;

			var invitation = this._onGoingInvitations[request.InvitationId];
			var channel = ChannelManager.GetChannelByEntityId(invitation.GetExtension(bgs.protocol.channel.v1.ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId);

			var notification = bgs.protocol.channel.v1.InvitationRemovedNotification.CreateBuilder().SetInvitation(invitation.ToBuilder()).SetReason((uint)InvitationRemoveReason.Accepted);
			this._onGoingInvitations.Remove(invitation.Id);
			var a = GameAccountManager.GetAccountByPersistentID(invitation.InviteeIdentity.GameAccountId.Low);

			//client.MakeTargetedRPC(this, (lid) =>
			//	bgs.protocol.channel.v1.ChannelInvitationListener.CreateStub(client).OnReceivedInvitationRemoved(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));
			
			var mem = a.LoggedInClient;



			client.MakeTargetedRPC(this, (lid) => bgs.protocol.channel.v1.ChannelInvitationListener.CreateStub(client).OnReceivedInvitationRemoved(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));

			
			channel.Join(mem, request.ObjectId); // add invitee to channel -- so inviter and other members will also be notified too.

			var inviter = GameAccountManager.GetAccountByPersistentID(invitation.InviterIdentity.GameAccountId.Low);

			var stateNotification = bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder()
				.SetAgentId(bgs.protocol.EntityId.CreateBuilder().SetHigh(0).SetLow(0).Build())
				.SetStateChange(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation).SetReason(0).Build())
				.Build();

			var build = bgs.protocol.channel.v1.JoinNotification.CreateBuilder()
				.SetChannelState(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation).SetReason(0).Build()).Build();

			foreach (var member in channel.Members.Keys)
			{
				member.MakeTargetedRPC(channel, (lid) => bgs.protocol.channel.v1.ChannelListener.CreateStub(member).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, stateNotification, callback => { }));
				//member.MakeTargetedRPC(channel, (lid) => bgs.protocol.channel.v1.ChannelListener.CreateStub(member).OnJoin(new HandlerController() { ListenerId = lid }, build, callback => { }));
			}

			return channel;
		}

		public void HandleDecline(BattleClient client, bgs.protocol.channel.v1.DeclineInvitationRequest request)
		{
			if (!this._onGoingInvitations.ContainsKey(request.InvitationId)) return;
			var invitation = this._onGoingInvitations[request.InvitationId];

			var inviter = GameAccountManager.GetAccountByPersistentID(invitation.InviterIdentity.GameAccountId.Low);
			if (inviter == null || inviter.LoggedInClient == null) return;

			var notification =
				bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder()
				.SetAgentId(bgs.protocol.EntityId.CreateBuilder().SetHigh(0).SetLow(0)) // caps have this set to high: 0 low: 0 /raist.
				.SetStateChange(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation)
				.SetReason((uint)InvitationRemoveReason.Declined));

			this._onGoingInvitations.Remove(invitation.Id);
			GoingInvitations.Remove(request.InvitationId);

			inviter.LoggedInClient.MakeTargetedRPC(inviter.LoggedInClient.CurrentChannel, (lid) =>
				bgs.protocol.channel.v1.ChannelListener.CreateStub(inviter.LoggedInClient).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));
		}

		public void Revoke(BattleClient client, bgs.protocol.channel.v1.RevokeInvitationRequest request)
		{
			if (!this._onGoingInvitations.ContainsKey(request.InvitationId)) return;
			this.CheckSubscribers();
			var invitation = this._onGoingInvitations[request.InvitationId];
			var inviter = GameAccountManager.GetAccountByPersistentID(invitation.InviterIdentity.GameAccountId.Low);

			var channel = ChannelManager.GetChannelByEntityId(request.ChannelId);

			//notify inviter about revoke
			var updateChannelNotification =
				bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder()
				.SetAgentId(bgs.protocol.EntityId.CreateBuilder().SetHigh(0).SetLow(0)) // caps have this set to high: 0 low: 0 /dustin
				.SetStateChange(bgs.protocol.channel.v1.ChannelState.CreateBuilder().AddInvitation(invitation)
				.SetReason((uint)InvitationRemoveReason.Revoked));

			this._onGoingInvitations.Remove(request.InvitationId);
			GoingInvitations.Remove(request.InvitationId);

			inviter.LoggedInClient.MakeTargetedRPC(inviter.LoggedInClient.CurrentChannel, (lid) =>
				bgs.protocol.channel.v1.ChannelListener.CreateStub(client).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, updateChannelNotification.Build(), callback => { }));

			//notify invitee about revoke
			var invitationRemoved =
				bgs.protocol.channel.v1.InvitationRemovedNotification.CreateBuilder()
				.SetInvitation(invitation);
			//.SetReason((uint)InvitationRemoveReason.Declined);

			if (!this.Subscribers.Any(subscriber => subscriber.Key.Account.GameAccount.BnetEntityId.Low == invitation.InviteeIdentity.AccountId.Low)) return;

			client.MakeTargetedRPC(this, (lid) =>
				bgs.protocol.channel.v1.ChannelInvitationListener.CreateStub(client).OnReceivedInvitationRemoved(new HandlerController() { ListenerId = lid }, invitationRemoved.Build(), callback => { }));
		}

		public enum InvitationRemoveReason : uint
		{
			Accepted = 0x0,
			Declined = 0x1,
			Revoked = 0x2
		}
	}
}
