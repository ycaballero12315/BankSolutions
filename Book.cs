using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public class Book:Publications
    {
        public Book(string title, string publisher, string author) : this(title, string.Empty,  author, publisher)
        {
        }
        public Book(string title, string isbn, string author, string publisher) : base(title, publisher, PublicationType.Book)
        {
            if(!string.IsNullOrEmpty(isbn))
            {
                if(!(isbn.Length == 10 | isbn.Length == 13))
                    throw new ArgumentException($"El ISBN debe tener 10 o 13 caracteres: {nameof(isbn)}");
                if(!ulong.TryParse(isbn, out _)) 
                    throw new ArgumentException($"El ISBN debe contener solo dígitos: {nameof(isbn)}");
                ISBN = isbn;
                Author = author;
            }
        }
        public string ISBN { get; }
        public string Author { get; }

        public decimal Price { get; private set; }

        // A three-digit ISO currency symbol.
        public string? Currency { get; private set; }

        // Returns the old price, and sets a new price.
        public decimal SetPrice(decimal price, string currency)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "The price cannot be negative.");
            decimal oldValue = Price;
            Price = price;

            if (currency.Length != 3)
                throw new ArgumentException("The ISO currency symbol is a 3-character string.");
            Currency = currency;

            return oldValue;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Book book)
                return false;
            else
                return ISBN == book.ISBN;
        }

        public override int GetHashCode() => ISBN.GetHashCode();

        public override string ToString() => $"{(string.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
    }
}
