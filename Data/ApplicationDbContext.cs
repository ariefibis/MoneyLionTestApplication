using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using MoneyLionTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyLionTestApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Get key and IV from a Base64String or any other ways.
        // You can generate a key and IV using "AesProvider.GenerateKey()"
        private readonly byte[] _encryptionKey = Encoding.ASCII.GetBytes("VEO9q9TMCCIWoWx9tCVmiw");
        private readonly byte[] _encryptionIV = Encoding.ASCII.GetBytes("rHAjEvYOYcXNhgjlOGaVng");
        private readonly IEncryptionProvider _provider;
        private readonly DbContextOptions _options;

        [Obsolete]
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
            this._provider = new AesProvider(_encryptionKey, this._encryptionIV);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryption(this._provider);

        }
    }
}
