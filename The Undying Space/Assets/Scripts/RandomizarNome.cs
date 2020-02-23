using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class RandomizarNome
    {
        public static Random rd;
        public static List<string> Nomes { get; private set; }

        public static void CarregarClasse()
        {
            if (rd == null)
                rd = new Random();
            if (Nomes == null)
                Nomes = new List<string>() { "Mognaephus","Lephavis","Yudion","Thigilles","Zathea","Bonus","Phedalea","Caloturn","Trion OS",
                "Derth IFU","Bogiuzuno","Kenuanov","Doccion","Melmoth","Zeter","Sahiri","Lozoyama","Chaater","Drypso JTVK","Phides WG5O",
                "Zolaotis","Oviuvis","Uchurn","Enzion","Gihiri","Cheonerth","Strobetune","Nosunerth","Chao T1DV","Brarvis DX3","Kistrouphus",
                "Vadrehines","Nalroria","Xosorix","Pater","Lluihines","Bekithea","Marvis 84F","Sao I0C6","Kodrautov","Monohiri","Valov",
                "Dankoth","Latera","Nuewei","Griguturn","Goucarro","Ceon RCQ","Bides S6O","Yathelea","Sibrulia","Kunkuna","Kadroria",
                "Bemia","Caitania","Coyathea","Grisucury","Lara A7H","Streon M47Q","Eccoater","Deccenov","Obrion","Holnion","Reorus",
                "Koitis","Guarus","Gnaerus","Beon 9OAS","Lillon CZJT","Rilupra","Azeuliv","Dabrilles","Kennao","Cuahines","Ziagawa",
                "Thizacarro","Thevipra","Darth Z11G","Neon L1","Cesuiclite","Kutreruta","Dillichi","Thillyke","Doubos","Uelia","Bunebos",
                "Netestea","Vilia OIYM","Tradus TPB9","Onveyama","Ocuruta","Tolnagua","Bothillon","Ziruta","Iuhiri","Zuxegawa","Chunathea",
                "Lorix DI3","Lleon 0","Vastrater","Thenrarus","Vaminda","Zenzao","Niulea","Aenerth","Daowei","Chegonov","Lov 48F",
                "Thara D4MD","Ephutis","Vustrehines","Gollade","Regnoria","Yuter","Gunus","Bregutov","Cruzazuno","Driri 521","Cosie LG",
                "Oceutune","Vilrapra","Mulnides","Ucadus","Pounov","Moutune","Gailara","Nukeclite","Gore 2P","Phade 48AQ","Izaerilia",
                "Naziuter","Vagruna","Runvilles","Onus","Mistea","Trenanov","Briulea","Vone 1332","Gnapus G576","Ribeolara","Xuleyama",
                "Dandoth","Yiverth","Giolara","Ouwei","Gnivicury","Zipurus","Sade B5","Thagua T10","Yibreinov","Chathiria","Hetriri","Ezora",
                "Diogawa","Duahines","Gnogomia","Saulara","Larth 044","Breron 60G","Thunuter","Richoimia","Nankorth","Ulrorix","Chueliv",
                "Lahines","Laiyama","Thakirilia","Criea ZJX","Drorix 0","Udrithea","Nagnulara","Hegrurn","Gunilia","Unia","Belia","Neitune",
                "Troalara","Phyke JPQ","Llillon 98M","Occeomia","Nesulea","Rongeshan","Vuminda","Mouturn","Cezuno","Viopra","Duivis",
                "Nyke PPG6","Crillon 362","Sindailara","Unkeamia","Kaphion","Ronnypso","Luamia","Roania","Vonalea","Lobiter","Brore TT2",
                "Dinda 0YDX","Nulroinov","Convoinus","Kongion","Xindurn","Laewei","Korus","Zoxetania","Thodaturn","Villon 7","Vinda 319",
                "Kodrathea","Beliaphus","Halmilia","Bephara","Uthea","Duanerth","Deocarro","Strometania","Noria M26","Noth TJG","Yusunov",
                "Movepra","Uliuq","Xidreshan","Doarilia","Duihines","Mogophus","Dukewei","Gnars NH7T","Lleshan L986","Picciezuno",
                "Cutricarro","Thengeron","Kobrinda","Boithea","Yowei","Chenotania","Thaonus","Colla V5","Cronoe MT4G","Tuzaria",
                "Chondeuvis","Rivone","Vegypso","Chicarro","Oustea","Gakoruta","Micuvis","Drao S7I","Vore RH2P","Ingepra","Sunutune",
                "Cebomia","Linvilles","Xanides","Catov","Thadunides","Vaevis","Drerth Y186","Momia PU7","Rocucarro","Onreitov","Zocrillon",
                "Vagnilia","Retune","Muacury","Llaxonerth","Grolobos","Gnides V4Z7","Thov 4N2","Vonkouphus","Gongonov","Palrosie","Kilromia",
                "Begawa","Tatov","Vemater","Bakilea","Grapus 9O1","Drorth 78","Ponnuatania","Ulmalara","Xedrolla","Tengapus","Chiogawa",
                "Deipra","Ciyatera","Nigotania","Gyke GJ","Moth 9RT3","Tabriunus","Chunoatis","Destromia","Runniuq","Leiter","Bauliv",
                "Zulanov","Llazaria","Grorth E20","Sichi FPE","Nuvotune","Cemigantu","Xelviea","Sulvoria","Eagantu","Atune","Chagucarro",
                "Sibitis","Varvis 1RJ","Loth 2S","Thubiotera","Xineinerth","Chocrarvis","Xacrion","Namia","Lierilia","Nakutov","Siutania",
                "Trarvis C5G","Striea V","Cidetis","Yesuaclite","Pillolla","Occapus","Anus","Ioter","Cotithea","Lepunus","Merth 73","Noria 3KB",
                "Agrearia","Ithiurus","Humomia","Umeon","Ginope","Reruta","Cechathea","Greitov","Villon PH1","None LO","Golvielara","Thelmitera",
                "Abrion","Vonzurn","Geturn","Kenope","Vudohines","Llolugawa","Thinda UOI","Grolla 9","Gabaurilia","Ruccatune","Sognuna","Nunzion",
                "Uepra","Cetera","Cruhinerth","Muchalea","Lion W49","Crippe YJD","Melmozuno","Nellinia","Azuna","Nistrao","Sealia","Sater",
                "Siyurus","Grisater","Grosie CCT","Gneron K6","Xaphoahiri","Bebboalia","Dandarth","Pinrore","Thiuclite","Souruta","Nusestea",
                "Begohines","Croth HOMR","Nion 5NO","Vignunus","Rolraistea","Yomiuq","Sulmars","Tounerth","Kaoclite","Zuriclite","Strerecarro",
                "Viri 2F8","Phara Y","Zangonides","Emaenus","Nagnarvis","Hindichi","Panides","Toinia","Cavanus","Stroxaturn","Grichi L87V",
                "Strypso 6T4U","Chunneastea","Cudretis","Huccao","Thasyke","Saenus","Yunia","Phimahines","Viyevis","Theon 7","Gnion 19L",
                "Vibbalara","Paphaupra","Zilleron","Thebapus","Diomia","Laucarro","Bopotania","Drohuvis","Zinda 2CKJ","Phonoe 606",
                "Lathietania","Rocitera","Gesorth","Rochorix","Yiezuno","Vimia","Breoria","Licurus","Llosie OKC","Phides 780","Botraliv",
                "Pinzeanerth","Elragua","Xitrichi","Vetis","Iotune","Drocicarro","Luxohiri","Sorix 9L","Creon F74M","Celuclite","Estreanov",
                "Isara","Zulmov","Habos","Alia","Treuzuno","Munitov","Dichi 20E","Zilia ZG0","Yusuetune","Gonnaoyama","Picrolla","Ungoria",
                "Yuzuno","Auria","Llazecarro","Cezotera","Gone M00M","Seshan 6CN","Nugoutov","Lanzetis","Zathoth","Chedradus","Kauphus",
                "Pialara","Duloruta","Drahithea","Chichi T","Gnone JLI","Liceiyama","Mastriuliv","Elrone","Hacrinda","Zaiter","Doruta",
                "Crikuter","Breyiter","Gonoe 65CU","Chinda UFZ","Olvazuno","Tabronides","Ribriri","Bibrone","Saeclite","Oilea","Githuhines",
                "Llazathea","Ninda O3FC","Golla BP","Xoduacury","Dunzaruta","Megnars","Hichadus","Chaogawa","Ibos","Dienus","Zaoruta",
                "Dov 9T5K","Drippe V8N",
            };
        }

        public static string RandomNome() => Nomes[rd.Next(Nomes.Count)];
    }
}
