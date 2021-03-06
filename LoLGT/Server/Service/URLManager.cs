﻿
namespace Server.Service
{
    using Newtonsoft.Json;
    using Server.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class URLManager
    {
        public static string server = "euw";
        public static string SummonerByName(string name)
        {
            string url = $"https://{server}.api.pvp.net/api/lol/{server}/v1.4/summoner/by-name/{name}?api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
            return url;
        }

        public static string SummonerMatchesById(int id)
        {
           string url = $"https://{server}.api.pvp.net/api/lol/{server}/v2.2/matchlist/by-summoner/{id}?api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
           return url;
        }

        public static string SummonerRankingById(int id)
        {
            string url = $"https://{server}.api.pvp.net/api/lol/{server}/v1.3/stats/by-summoner/{id}/ranked?season=SEASON2016&api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
            return url;
        }

        public static string SummonerGamesById(int id)
        {
            string url = $"https://{server}.api.pvp.net/api/lol/{server}/v1.3/game/by-summoner/{id}/recent?season=SEASON2016&api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
            return url;
        }

        public static string ExtractID(this string request)
        {
            Dictionary<string, Summoner> player;
            if (request != null)
            {
                player = SerializerManager.PlayerDataSerializer(request);
                return player.FirstOrDefault().Value.Id.ToString();
            }
            else
            {
                return null;
            }
        }

    //    {"roni":{"id":30286631,"name":"Roni","profileIconId":576,"revisionDate":1469253820000,"summonerLevel":30}}
    }
}
