using evidenceKosmonautu.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using evidenceKosmonautu.Database;
using evidenceKosmonautu.Models;

namespace evidenceKosmonautu.Services
{
    public class KosmonautService : IService<SuperheroDTO>
    {
        private readonly MainContext _context;

        public KosmonautService(MainContext context)
        {
            _context = context;
        }

        IEnumerable<SuperheroDTO> IService<SuperheroDTO>.GetAll()
        {
            return _context.Superheroes.Select(s => new SuperheroDTO
            {
                Id = s.Id,
                Jmeno = s.Jmeno,
                Prijmeni = s.Prijmeni,
                Superschopnosti = s.jtHeroPower.Where(w => w.SuperheroId == s.Id).Select(s => s.SuperpowerModel.Nazev).ToList()
            }).AsEnumerable();
        }

        SuperheroDTO IService<SuperheroDTO>.GetById(int id)
        {
            return _context.Superheroes.Where(w => w.Id == id).Select(s => new SuperheroDTO
            {
                Id = s.Id,
                Jmeno = s.Jmeno,
                Prijmeni = s.Prijmeni,
                Superschopnosti = s.jtHeroPower.Where(w => w.SuperheroId == id).Select(s => s.SuperpowerModel.Nazev).ToList()
            }).FirstOrDefault();
        }

        void IService<SuperheroDTO>.Create(SuperheroDTO dto)
        {
            SuperheroModel destination = new SuperheroModel
            {
                Jmeno = dto.Jmeno,
                Prijmeni = dto.Prijmeni
            };
            _context.Superheroes.Add(destination);
            _context.SaveChanges();

            foreach (var superpowerId in dto.SuperschopnostiIds)
            {
                var jtHeroPower = new jt_superhero_superpower
                {
                    SuperheroId = destination.Id,
                    SuperpowerId = superpowerId
                };

                _context.jtHeroPower.Add(jtHeroPower);
                _context.SaveChanges();
            }
        }

        void IService<SuperheroDTO>.Update(SuperheroDTO dto)
        {
            SuperheroModel source = _context.Superheroes.FirstOrDefault(f => f.Id == dto.Id);

            source.Jmeno = dto.Jmeno;
            source.Prijmeni = dto.Prijmeni;
            source.jtHeroPower = dto.SuperschopnostiIds.Select(sel => new jt_superhero_superpower
            {
                SuperheroId = source.Id,
                SuperpowerId = sel
            }).ToList();

            var entries = _context.jtHeroPower.Where(w => w.SuperheroId == dto.Id);
            _context.jtHeroPower.RemoveRange(entries);

            _context.Update(source);
            _context.SaveChanges();
        }

        void IService<SuperheroDTO>.Delete(int id)
        {
            var d = _context.Superheroes.FirstOrDefault(f => f.Id == id);
            _context.Superheroes.Remove(d);
            _context.SaveChanges();
        }
    }
}
