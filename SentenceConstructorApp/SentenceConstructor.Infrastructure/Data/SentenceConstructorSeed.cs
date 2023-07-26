using SentenceConstructor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SentenceConstructor.Infrastructure.Data
{
    public static class SentenceConstructorSeed
    {

        public static async Task SeedAsync(SentenceConstructorContext context)
        {
            try
            {
                string currentDir = Path.GetDirectoryName(Environment.CurrentDirectory);
                string fullPath = Path.Join(currentDir, "SentenceConstructor.Infrastructure\\Data\\SeedData");

                //var adjectivesDatas = File.ReadAllText($"{fullPath}\\adjectives.json");
                //var adjectivess = JsonSerializer.Deserialize<List<Word>>(adjectivesDatas);

                if (!context.Words.Any())
                {

                    var adjectivesData = File.ReadAllText($"{fullPath}\\adjectives.json");
                    var adjectives = JsonSerializer.Deserialize<List<Word>>(adjectivesData);
                    context.Words.AddRange(adjectives);

                    var adverbsData = File.ReadAllText($"{fullPath}\\adverbs.json");
                    var adverbs = JsonSerializer.Deserialize<List<Word>>(adverbsData);
                    context.Words.AddRange(adverbs);

                    var conjunctionsData = File.ReadAllText($"{fullPath}\\conjunctions.json");
                    var conjunctions = JsonSerializer.Deserialize<List<Word>>(conjunctionsData);
                    context.Words.AddRange(conjunctions);

                    var determinersData = File.ReadAllText($"{fullPath}\\determiners.json");
                    var determiners = JsonSerializer.Deserialize<List<Word>>(determinersData);
                    context.Words.AddRange(determiners);

                    var exclamationsData = File.ReadAllText($"{fullPath}\\exclamations.json");
                    var exclamations = JsonSerializer.Deserialize<List<Word>>(exclamationsData);
                    context.Words.AddRange(exclamations);

                    var nounsData = File.ReadAllText($"{fullPath}\\noun.json");
                    var nouns = JsonSerializer.Deserialize<List<Word>>(nounsData);
                    context.Words.AddRange(nouns);

                    var prepositionsData = File.ReadAllText($"{fullPath}\\prepositions.json");
                    var prepositions = JsonSerializer.Deserialize<List<Word>>(prepositionsData);
                    context.Words.AddRange(prepositions);

                    var pronounsData = File.ReadAllText($"{fullPath}\\pronouns.json");
                    var pronouns = JsonSerializer.Deserialize<List<Word>>(pronounsData);
                    context.Words.AddRange(pronouns);

                    var verbsData = File.ReadAllText($"{fullPath}\\verbs.json");
                    var verbs = JsonSerializer.Deserialize<List<Word>>(verbsData);
                    context.Words.AddRange(verbs);

                }


                if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

               var error = ex.Message;
            }
        }




    }
}
