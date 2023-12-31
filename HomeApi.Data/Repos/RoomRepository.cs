﻿using System.Linq;
using System.Threading.Tasks;
using HomeApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Data.Repos
{
	/// <summary>
	/// Репозиторий для операций с объектами типа "Room" в базе
	/// </summary>
	public class RoomRepository : IRoomRepository
	{
		private readonly HomeApiContext _context;

		public RoomRepository (HomeApiContext context)
		{
			_context = context;
		}

		/// <summary>
		///  Найти комнату по имени
		/// </summary>
		public async Task<Room> GetRoomByName(string name)
		{
			return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
		}

		/// <summary>
		///  Добавить новую комнату
		/// </summary>
		public async Task AddRoom(Room room)
		{
			var entry = _context.Entry(room);
			if (entry.State == EntityState.Detached)
				await _context.Rooms.AddAsync(room);

			await _context.SaveChangesAsync();
		}

		public async Task ReplaceRoom(Room existingRoom, Room newRoom) {
			var room = await _context.Rooms.FindAsync(existingRoom.Id);
			if (room == null) {
				return;
			}
			existingRoom.Name = newRoom.Name;
			existingRoom.Area = newRoom.Area;
			existingRoom.GasConnected = newRoom.GasConnected;
			existingRoom.Voltage = newRoom.Voltage;
			await _context.SaveChangesAsync();
		}
	}
}