﻿//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using System.Text;
//Blizzless Project 2022 
using System.Threading.Tasks;

namespace DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Player
{
   [Message(new[] {
        Opcodes.HighestHeroSoloRiftLevelMessage,
        })]
    public class PlayerIntValMessage : GameMessage
    {
        public int Field0;
        public int Field1;
        public PlayerIntValMessage() : base(Opcodes.HighestHeroSoloRiftLevelMessage) { }

        public override void Parse(GameBitBuffer buffer)
        {
            Field0 = buffer.ReadInt(3);
            Field1 = buffer.ReadInt(32);
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteInt(3, Field0);
            buffer.WriteInt(32, Field1);
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("IntDataMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("Field0: 0x" + Field0.ToString("X8") + " (" + Field0 + ")");
            b.Append(' ', pad); b.AppendLine("Field1: 0x" + Field1.ToString("X8") + " (" + Field1 + ")");
            b.Append(' ', --pad);
            b.AppendLine("}");
        }


    }
}
