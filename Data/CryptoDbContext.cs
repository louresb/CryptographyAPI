using Microsoft.EntityFrameworkCore;
using CryptographyAPI.Models;
using System.Security.Cryptography;

namespace CryptographyAPI.Data
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
        {
            CryptEntities = Set<CryptEntity>();
        }

        public DbSet<CryptEntity> CryptEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure encryption conversion for UserDocument property
            modelBuilder.Entity<CryptEntity>().Property(e => e.UserDocument).HasConversion(
                v => Encrypt(v),
                v => Decrypt(v)
            );

            // Configure encryption conversion for CreditCardToken property
            modelBuilder.Entity<CryptEntity>().Property(e => e.CreditCardToken).HasConversion(
                v => Encrypt(v),
                v => Decrypt(v)
            );

            base.OnModelCreating(modelBuilder);
        }

        private static readonly byte[] Key = new byte[] { 0x8B, 0x4D, 0x95, 0xA1, 0x62, 0xF3, 0x4A, 0x4D, 0xA1, 0xCA, 0xB3, 0xF4, 0xD4, 0xE3, 0xE1, 0xE7 };
        private static readonly byte[] IV = new byte[] { 0x8E, 0x99, 0xC6, 0xFE, 0xD3, 0xD8, 0xA0, 0xBC, 0x8E, 0x99, 0xC6, 0xFE, 0xD3, 0xD8, 0xA0, 0xBC };

        // Encrypts the given value using AES algorithm
        private static string Encrypt(string value)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(value);
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        // Decrypts the given value using AES algorithm
        private static string Decrypt(string value)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(Convert.FromBase64String(value));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}
