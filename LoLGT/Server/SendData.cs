﻿using Server.Service;
using Server.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class SendData : WebSocketBehavior
    {
        public SendData()
        {
        }

        protected override void OnOpen()
        {
            Console.WriteLine("Conn opened");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            DataFetcher dataFetcher = new DataFetcher();

            LoLClient lol = new LoLClient();
            if (e.Data.Contains("#01"))
            {
                Send(lol.GetSummonerIdByName(e.Data.Substring(3)));
            }
            else if (e.Data.Contains("#04"))
            {
                // ↓ Tony, add here the method for ChampionStatisticsActivity
                //Send ($"#05{METHOD NAME)");
                string jsonChampStats = dataFetcher.ChampionStatsData(e.Data.Substring(3));
                Console.WriteLine(jsonChampStats);
                Send($"{jsonChampStats}");
            }
            else if (e.Data.Contains("#06"))
            {
                // ↓ Tony, add here the method for MatchHistory
                //Send ($"#07{METHOD NAME)");
                string jsonMatchesHistory = dataFetcher.MatchHistoryData(e.Data.Substring(3));
                Send($"{jsonMatchesHistory}");
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
        }

        // To send data to a client from wssv:
        // Send()

        // To send to all clients:
        // wssv.WebSocketServices["/SendData"].Sessions.Broadcast();
    }
}
