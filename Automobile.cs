using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankSolutions
{
    public class Automobile
    {
        public Automobile(string make, string model, int year)
        {
            if (make == null)
                throw new ArgumentNullException(nameof(make), "El elemento no debe ser null");
            else if (string.IsNullOrWhiteSpace(make))
                throw new ArgumentException("El elemento no debe ser vacio o solo espacios en blanco", nameof(make));
            Make = make;

            if (model == null)
                throw new ArgumentNullException(nameof(model), "El elemento no debe ser null");
            else if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("El elemento no debe ser vacio o solo espacios en blanco", nameof(model));
            Model = model.Trim();

            if (year < 1857 || year >= DateTime.Now.Year-2)
                throw new ArgumentException($"Anno incorrecto, no puede ser sobre esas fechas {nameof(year)}");
            Year = year;
        } 
        public string Make { get; }
        public string Model { get; }
        public int Year { get; }

        public override string ToString()
        {
            return $"Make: {Make}, Model: {Model}, Year: {Year}";
        }
    }
}
