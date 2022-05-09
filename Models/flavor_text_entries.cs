namespace TrueLayerBackendEngineerChallenge.Models{
    public class flavor_text_entries{
        public string flavor_text { get; set; }  

        public Language language {get; set;}
        public Version version {get; set;}
    }

    public class Language{
        public string name { get; set; }      
    }
    
    public class Version{
        public string name { get; set; }      
    }
}