﻿using JagtApp.Enums;
using JagtApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JagtApp.Models
{
    public class Firearm //Klassen "Firearm" omhandler skydevåbnet, i nuværende tilfælde riflen - men den er ikke kaldt "Rifle", fordi jeg ønsker at fremtidssikre projektet til en dag at kunne håndtere øvrige våbentyper. 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Navnet på skydevåbenet er påkrævet.")]
        [StringLength(100, ErrorMessage = "Navnet på skydevåbenet kan højst være 100 tegn.")]
        public string FAName { get; set; }

        [Required(ErrorMessage = "Ejerens ID er påkrævet.")]
        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        [Required(ErrorMessage = "Våbentypen er påkrævet.")]
        public FirearmType Type { get; set; }

        [Required(ErrorMessage = "Tillaldelsens udløbsdato er påkrævet.")]
        public DateOnly LicenceExpirationDate { get; set; }

        [Required(ErrorMessage = "Listen over understøttede kalibre er påkrævet. Denne skal indeholde mindst ét kaliber.")]
        public List<Caliber> SupportedCalibers { get; set; }

        public Firearm() { }

        public Firearm(int fAId, string fAName, string ownerId, FirearmType type, DateOnly licenceExpirationDate, List<Caliber> supportedCalibers)
        {
            Id = fAId;
            FAName = fAName;
            OwnerId = ownerId;
            Type = type;
            LicenceExpirationDate = licenceExpirationDate;
            SupportedCalibers = supportedCalibers;
        }
    }
}
