#region Using directives
using System;
#endregion

namespace GameServerInfo
{
	internal class Source : GameServerInfo.Protocol
	{
		// FF FF FF FF 54
		private const string _QUERY_DETAILS = @"ÿÿÿÿT";

		// FF FF FF FF 56
		private const string _QUERY_RULES = @"ÿÿÿÿV";

		// FF FF FF FF 55
		private const string _QUERY_PLAYERS = @"ÿÿÿÿU";

		/// <param name="host">Serverhost address</param>
		/// <param name="port">Serverport</param>
		public Source( string host, int port )
		{
			base._protocol = GameProtocol.Source;
			Connect( host, port );
		}

		/// <summary>
		/// Querys the serverinfos
		/// </summary>
		public override void GetServerInfo()
		{
			Query( _QUERY_DETAILS );
			ParseDetails();

			Query( _QUERY_RULES );
			ParseRules();

			Query( _QUERY_PLAYERS );
			ParsePlayers();
		}

		private void ParseDetails()
		{
			_params["protocolver"] = Response[5].ToString();
			_params["hostname"] = ReadNextParam( 6 );
			_params["mapname"] = ReadNextParam();
			_params["mod"] = ReadNextParam();
			_params["modname"] = ReadNextParam();

			int i = Response.Length - 7;
			_params["players"] = Response[i++].ToString();
			_params["maxplayers"] = Response[i++].ToString();
			_params["botcount"] = Response[i++].ToString();
			_params["servertype"] = ( (char)Response[i++] ).ToString();
			_params["serveros"] = ( (char)Response[i++] ).ToString();
			_params["passworded"] = Response[i++].ToString();
			_params["secureserver"] = Response[i].ToString();
		}

		private void ParseRules()
		{
			string key, val;
			int ruleCount = BitConverter.ToInt16( Response, 5 );
			Offset = 7;

			for ( int i = 0; i < ( ruleCount * 2 ); i++ )
			{
				key = ReadNextParam();
				val = ReadNextParam();
				if ( key.Length == 0 )
				{
					continue;
				}
				_params[key] = val;
			}
		}

		private void ParsePlayers()
		{
			_params["numplayers"] = Response[5].ToString();
			Offset = 6;

			int pNr;
			for ( int i = 0; i < Response[5]; i++ )
			{
				pNr = _players.Add( new Player() );
				_players[pNr].Parameters.Add( "playernr", Response[Offset++].ToString() );
				_players[pNr].Name = ReadNextParam();
				_players[pNr].Score = BitConverter.ToInt32( Response, Offset );
				Offset += 4;
				_players[pNr].Time = new TimeSpan( 0, 0, (int)BitConverter.ToSingle( Response, Offset ) );
				Offset += 4;
			}
		
			for ( int i = 0; i < Response[5]; i++ )
			{
				pNr = _players.Add( new Player() );
				try
				{
					_players[pNr].Parameters.Add( "playernr", Response[Offset++].ToString() );
					_players[pNr].Name = ReadNextParam();
					_players[pNr].Score = BitConverter.ToInt32( Response, Offset );
					Offset += 4;
					_players[pNr].Time = new TimeSpan( 0, 0, (int)BitConverter.ToSingle( Response, Offset ) );
					Offset += 4;
				}
				catch(Exception)
				{
					Offset += 8;
					_players.RemoveAt(pNr);
				}
			}
		}
	}

	/// <summary>
	/// Steam Application Ids
	/// </summary>
	public enum SteamApplicationId
	{
		/// <summary>
		/// A dedicated server
		/// </summary>
		DedicatedServer = 5,
		
		/// <summary>
		/// Counter strike
		/// </summary>
		CounterStrike = 10,

		/// <summary>
		/// Team fortress classic
		/// </summary>
		TeamFortessClassic = 20,

		/// <summary>
		/// Day of defeat
		/// </summary>
		DayOfDefeat = 30,

		/// <summary>
		/// death match classic
		/// </summary>
		DeathMatchClassic = 40,

		/// <summary>
		/// opposing force
		/// </summary>
		OpposingForce = 50,

		/// <summary>
		/// Ricochet
		/// </summary>
		Ricochet = 60,

		/// <summary>
		/// HalfLife
		/// </summary>
		HalfLife = 70,

		/// <summary>
		/// Counter stike condition zero
		/// </summary>
		CounterStikeConditionZero = 80
	}
}