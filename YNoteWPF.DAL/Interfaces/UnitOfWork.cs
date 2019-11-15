﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;
using YNoteWPF.DAL.Interfaces;
using YNoteWPF.DAL.Repositories;

namespace YNoteWPF.DAL.Interfaces
{
    public class UnitOfWork //:IDisposable
    {
        private YNoteDbContext db = new YNoteDbContext();
        public UserRepository Users { get; set; }

        public SpaceRepository Spaces { get; set; }

        public GroupRepository Groups { get; set; }

        public NoteRepository Notes { get; set; }

        public TaskRepository Tasks { get; set; }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
