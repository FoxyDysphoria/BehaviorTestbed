using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BehaviourTestbed.Models
{
	class Location
	{
		private string ShortDesc;
		private string LongDesc;
		private string LocName;
		private List<Location> Connections;


		public Location(string name, string shortDesc, string longDesc)
		{
			LocName = name;
			ShortDesc = shortDesc;
			LongDesc = longDesc;
		}

		public string Glance() => ShortDesc;

		public string Look() => LongDesc;

		public string GetName() => LocName;

		public List<Location> GetConnections() => Connections;
		public void Connect(Location newConnection)
		{
			if (!Connections.Contains(newConnection))
				Connections.Add(newConnection);
			if (!newConnection.Connections.Contains(this))
				newConnection.Connections.Add(this);
		}
		public void AddConnections(IList<Location> newConnections)
		{
			foreach (Location loc in newConnections)
			{
				Connect(loc);
			}
		}
		public void RemoveConnection(Location connection)
		{
			Connections.Remove(connection);
		}
		public void RemoveAllConnections()
		{
			Connections.Clear();
		}

		public string EnterRoom() => $"{GetName()}\n{Glance()}";
	}
}
