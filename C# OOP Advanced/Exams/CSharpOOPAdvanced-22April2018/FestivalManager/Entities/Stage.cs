﻿namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		// да си вкарват през полетата бе
		private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);

        }
        
        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public ISet GetSet(string name)
        {
            return this.sets.FirstOrDefault(x => x.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.songs.FirstOrDefault(x => x.Name == name);
        }

        public IPerformer GetPerformer(string name)
        {
            return this.performers.FirstOrDefault(x => x.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(s => s.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(s => s.Name == name);
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(s => s.Name == name);
        } 
    }
}
