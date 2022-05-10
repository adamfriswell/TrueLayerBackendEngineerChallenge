using System.Collections.Generic;
using TrueLayerBackendEngineerChallenge.Models;

namespace TrueLayerBackendEngineerChallenge.Tests {
    public static class TestData {
        public const string BlackVersionFlavourText = "On raconte que la flamme du Dracaufeu s'intensifie après un combat difficile.";
        public const string BlackVersionLanguage = "fr";
        public const string BlackVersionName = "black";

        public const string CrystalVersionFlavourText = "It uses its wings to fly high. The temperature of its fire increases as it gains experience in battle.";
        public const string CrystalVersionLanguage = "en";
        public const string CrystalVersionName = "crystal";

        public const string RubyVersionFlavourText = "CHARIZARD flies around the sky in search of powerful opponents. It breathes fire of such great heat that it melts anything. However, it never turns its fiery breath on any opponent weaker than itself.";
        public const string RubyVersionFlavourTextTranslated = "Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wondrous heat yond 't melts aught. However,  't nev'r turns its fiery breath on any opponent weaker than itself.";
        public const string RubyVersionLanguage = "en";
        public const string RubyVersionName = "ruby";

        public const string PokemonSpeciesCharizardResult = "{\"flavor_text_entries\":[{\"flavor_text\":\"On raconte que la flamme du Dracaufeu s'intensifie après un combat difficile.\",\"language\":{\"name\":\"fr\",\"url\":\"https://pokeapi.co/api/v2/language/5/\"},\"version\":{\"name\":\"black\",\"url\":\"https://pokeapi.co/api/v2/version/17/\"}},{\"flavor_text\":\"It uses its wings to fly high. The temperature of its fire increases as it gains experience in battle.\",\"language\":{\"name\":\"en\",\"url\":\"https://pokeapi.co/api/v2/language/9/\"},\"version\":{\"name\":\"crystal\",\"url\":\"https://pokeapi.co/api/v2/version/6/\"}},{\"flavor_text\":\"CHARIZARD flies around the sky in search of powerful opponents. It breathes fire of such great heat that it melts anything. However, it never turns its fiery breath on any opponent weaker than itself.\",\"language\":{\"name\":\"en\",\"url\":\"https://pokeapi.co/api/v2/language/9/\"},\"version\":{\"name\":\"ruby\",\"url\":\"https://pokeapi.co/api/v2/version/7/\"}}]}";
        public const string UnexpectedJson = "{\"jsonNode\":\"test\"}";
        public const string FunTranslationRubyDescriptionExpectedResult = "{\"success\":{\"total\":1},\"contents\":{\"translated\":\"Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wondrous heat yond 't melts aught. However,  't nev'r turns its fiery breath on any opponent weaker than itself.\",\"text\":\"CHARIZARD flies around the sky in search of powerful opponents. It breathes fire of such great heat that it melts anything. However, it never turns its fiery breath on any opponent weaker than itself.\",\"translation\":\"shakespeare\"}}";
        public const string FunTranslationResultWithNoTranslation = "{\"contents\":{\"translation\":\"shakespeare\"}}";

        public static flavor_text_entry GetBlackVersionFlavorTextEntryObject() {
            return new flavor_text_entry{
                    flavor_text = TestData.BlackVersionFlavourText,
                    language = new Language{ 
                        name = TestData.BlackVersionLanguage
                    },
                    version = new Models.Version{
                        name = TestData.BlackVersionName
                    }
                };
        }

        public static flavor_text_entry GetCrystalVersionFlavorTextEntryObject() {
            return new flavor_text_entry{
                    flavor_text = TestData.CrystalVersionFlavourText,
                    language = new Language{ 
                        name = TestData.CrystalVersionLanguage
                    },
                    version = new Models.Version{
                        name = TestData.CrystalVersionName
                    }
                };
        }

        public static flavor_text_entry GetRubyVersionFlavorTextEntryObject() {
            return new flavor_text_entry{
                    flavor_text = TestData.RubyVersionFlavourText,
                    language = new Language{ 
                        name = TestData.RubyVersionLanguage
                    },
                    version = new Models.Version{
                        name = TestData.RubyVersionName
                    }
                };
        }

        public static List<flavor_text_entry> GetFlavorTextEntriesObject(){
            return new List<flavor_text_entry>{
                GetBlackVersionFlavorTextEntryObject(),
                GetCrystalVersionFlavorTextEntryObject(),
                GetRubyVersionFlavorTextEntryObject()
            };
        }

        public static List<flavor_text_entry> GetFlavorTextEntriesObjectWithoutRubyVersion(){
            return new List<flavor_text_entry>{
                GetBlackVersionFlavorTextEntryObject(),
                GetCrystalVersionFlavorTextEntryObject()
            };
        }

        public static List<flavor_text_entry> GetFlavorTextEntriesObjectWithBlackVersionOnly(){
            return new List<flavor_text_entry>{
                GetBlackVersionFlavorTextEntryObject()
            };
        }
    }
}
