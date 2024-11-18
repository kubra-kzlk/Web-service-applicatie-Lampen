﻿using lampen.Models;

namespace lampen.Services
{
    public class ManufacturerService
    {
        private readonly List<Manufacturer> _fabrikanten = new()
        {
            new Manufacturer { Id = 1, Naam = "Philips", Land = "Nederland", Beschrijving = "Wereldwijd leider in verlichtingsoplossingen." },
            new Manufacturer { Id = 2, Naam = "IKEA", Land = "Zweden", Beschrijving = "Bekend om betaalbare en stijlvolle woningdecoratie." }
        };

        public List<Manufacturer> GetAll() => _fabrikanten;

        public Manufacturer? GetById(int id) => _fabrikanten.FirstOrDefault(m => m.Id == id);

    }
}