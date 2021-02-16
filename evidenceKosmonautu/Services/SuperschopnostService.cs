using evidenceKosmonautu.Database;
using evidenceKosmonautu.DTOs;
using evidenceKosmonautu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evidenceKosmonautu.Services
{
    public class SuperschopnostService : IService<SuperpowerDTO>
    {
        private readonly MainContext _context;

        public SuperschopnostService(MainContext context)
        {
            _context = context;
        }

        void IService<SuperpowerDTO>.Create(SuperpowerDTO dto)
        {
            var destination = new SuperpowerModel 
            {
                Nazev = dto.Nazev
            };

            _context.Superschopnosti.Add(destination);
            _context.SaveChanges();

            foreach (var superheroId in dto.SuperheroesIds)
            {
                var jtHeroPower = new jt_superhero_superpower
                {
                    SuperpowerId = destination.Id,
                    SuperheroId = superheroId
                };

                _context.jtHeroPower.Add(jtHeroPower);
                _context.SaveChanges();
            }
        }

        void IService<SuperpowerDTO>.Delete(int id)
        {
            var d = _context.Superschopnosti.FirstOrDefault(f => f.Id == id);
            _context.Superschopnosti.Remove(d);
            _context.SaveChanges();
        }

        IEnumerable<SuperpowerDTO> IService<SuperpowerDTO>.GetAll()
        {
            return _context.Superschopnosti.Select(s => new SuperpowerDTO
            {
                Id = s.Id,
                Nazev = s.Nazev,
                Superheroes = s.jtHeroPower.Where(w => w.SuperpowerId == s.Id).Select(s => $"{s.SuperheroModel.Jmeno} {s.SuperheroModel.Prijmeni}").ToList()
            });
        }

        SuperpowerDTO IService<SuperpowerDTO>.GetById(int id)
        {
            return _context.Superschopnosti.Where(w => w.Id == id).Select(s => new SuperpowerDTO
            {
                Id = s.Id,
                Nazev = s.Nazev,
                Superheroes = s.jtHeroPower.Where(w => w.SuperpowerId == s.Id).Select(s => $"{s.SuperheroModel.Jmeno} {s.SuperheroModel.Prijmeni}").ToList()
            }).FirstOrDefault();
        }

        void IService<SuperpowerDTO>.Update(SuperpowerDTO dto)
        {
            var upd = _context.Superschopnosti.Where(w => w.Id == dto.Id).FirstOrDefault();

            upd.Nazev = dto.Nazev;
            upd.jtHeroPower = dto.SuperheroesIds.Select(s => new jt_superhero_superpower
            {
                SuperpowerId = upd.Id,
                SuperheroId = s
            }).ToList();

            var oldEntries = _context.jtHeroPower.Where(w => w.SuperpowerId == dto.Id);
            _context.jtHeroPower.RemoveRange(oldEntries);

            _context.Update(upd);
            _context.SaveChanges();
        }
    }
}
