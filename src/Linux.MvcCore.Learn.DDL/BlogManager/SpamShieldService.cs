using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Linux.MvcCore.Learn.Common;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public class SpamShieldService : ISpamShieldService
    {
        private readonly LearnContext context;

        private readonly ILogger _logger;

        public SpamShieldService(LearnContext context, ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");
            this.context = context;
        }

        public string CreateTick(string key)
        {
            var tick = ObjectId.NewObjectId().ToString();
            var spamHash = new SpamHash
            {
                SpamHashId = tick,
                PostKey = key,
                CreatedTime = DateTime.UtcNow
            };

            context.SpamHashs.Add(spamHash);
            context.SaveChanges();

            return tick;
        }

        public string GenerateHash(string tick)
        {

            var nonhash = string.Empty;
            if (tick.IsNullOrWhitespace())
                return nonhash;

            // var spamHash = _db.SelectKey<SpamHash>(DBTableNames.SpamHashes, tick);
            var spamHash = context.SpamHashs.Where(p => p.SpamHashId == tick).SingleOrDefault();

            if (spamHash == null || spamHash.Pass || !spamHash.Hash.IsNullOrWhitespace())
                return nonhash;

            spamHash.Hash = new Random().NextDouble().ToString();
            // _db.Update(DBTableNames.SpamHashes, spamHash);
            context.Entry<SpamHash>(spamHash).State = EntityState.Modified;
            context.SaveChanges();
            return spamHash.Hash;


        }

        public bool IsSpam(SpamShield command)
        {

            if (command.Tick.IsNullOrWhitespace() || command.Hash.IsNullOrWhitespace())
                return true;

            //  var spamHash = _db.SelectKey<SpamHash>(DBTableNames.SpamHashes, command.Tick);
            var spamHash = context.SpamHashs.Where(p => p.SpamHashId == command.Tick).SingleOrDefault();
            if (spamHash == null || spamHash.Pass || spamHash.Hash != command.Hash)
                return true;

            spamHash.Pass = true;
            // _db.Update(DBTableNames.SpamHashes, spamHash);
            context.Entry<SpamHash>(spamHash).State = EntityState.Modified;
            context.SaveChanges();
            return false;

        }
    }
}
