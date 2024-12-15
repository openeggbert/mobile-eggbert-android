// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.MyResource
using System.Collections.Generic;
using System.Globalization;

namespace WindowsPhoneSpeedyBlupi
{
    public static class MyResource
    {
        public static readonly int TX_BUTTON_PLAY;

        public static readonly int TX_BUTTON_MENU;

        public static readonly int TX_BUTTON_BACK;

        public static readonly int TX_BUTTON_RESTART;

        public static readonly int TX_BUTTON_CONTINUE;

        public static readonly int TX_BUTTON_BUY;

        public static readonly int TX_BUTTON_SETUP;

        public static readonly int TX_BUTTON_SETUP_SOUNDS;

        public static readonly int TX_BUTTON_SETUP_JUMP;

        public static readonly int TX_BUTTON_SETUP_ZOOM;

        public static readonly int TX_BUTTON_SETUP_ACCEL;

        public static readonly int TX_BUTTON_SETUP_RESET;

        public static readonly int TX_BUTTON_RANKING;

        public static readonly int TX_GAMER_TITLE;

        public static readonly int TX_GAMER_MDOORS;

        public static readonly int TX_GAMER_SDOORS;

        public static readonly int TX_GAMER_LIFES;

        public static readonly int TX_TRIAL1;

        public static readonly int TX_TRIAL2;

        public static readonly int TX_TRIAL3;

        public static readonly int TX_TRIAL4;

        public static readonly int TX_TRIAL5;

        public static readonly int TX_TRIAL6;

        public static readonly int TX_TRAINING101;

        public static readonly int TX_TRAINING102;

        public static readonly int TX_TRAINING103;

        public static readonly int TX_TRAINING104;

        public static readonly int TX_TRAINING105;

        public static readonly int TX_TRAINING106;

        public static readonly int TX_TRAINING107;

        public static readonly int TX_TRAINING108;

        public static readonly int TX_TRAINING109;

        public static readonly int TX_TRAINING110;

        public static readonly int TX_TRAINING111;

        public static readonly int TX_TRAINING112;

        public static readonly int TX_TRAINING113;

        public static readonly int TX_TRAINING114;

        public static readonly int TX_TRAINING115;

        public static readonly int TX_TRAINING116;

        public static readonly int TX_TRAINING117;

        public static readonly int TX_TRAINING118;

        public static readonly int TX_TRAINING119;

        public static readonly int TX_TRAINING120;

        public static readonly int TX_TRAINING121;

        public static readonly int TX_TRAINING122;

        public static readonly int TX_TRAINING123;

        public static readonly int TX_TRAINING201;

        public static readonly int TX_TRAINING202;

        public static readonly int TX_TRAINING203;

        public static readonly int TX_TRAINING204;

        public static readonly int TX_TRAINING205;

        public static readonly int TX_TRAINING206;

        public static readonly int TX_TRAINING207;

        public static readonly int TX_TRAINING208;

        public static readonly int TX_TRAINING209;

        public static readonly int TX_TRAINING210;

        public static readonly int TX_TRAINING301;

        public static readonly int TX_TRAINING302;

        public static readonly int TX_TRAINING303;

        public static readonly int TX_TRAINING304;

        public static readonly int TX_TRAINING305;

        public static readonly int TX_TRAINING306;

        public static readonly int TX_TRAINING307;

        public static readonly int TX_TRAINING308;

        public static readonly int TX_TRAINING309;

        public static readonly int TX_TRAINING310;

        public static readonly int TX_TRAINING311;

        public static readonly int TX_TRAINING401;

        public static readonly int TX_TRAINING402;

        public static readonly int TX_TRAINING403;

        public static readonly int TX_TRAINING404;

        public static readonly int TX_TRAINING405;

        public static readonly int TX_TRAINING406;

        public static readonly int TX_TRAINING407;

        public static readonly int TX_TRAINING408;

        public static readonly int TX_TRAINING409;

        public static readonly int TX_TRAINING410;

        public static readonly int TX_TRAINING101a;

        public static readonly int TX_TRAINING102a;

        public static readonly int TX_TRAINING103a;

        public static readonly int TX_TRAINING104a;

        public static readonly int TX_TRAINING105a;

        public static readonly int TX_TRAINING106a;

        public static readonly int TX_TRAINING107a;

        public static readonly int TX_TRAINING108a;

        public static readonly int TX_TRAINING109a;

        public static readonly int TX_TRAINING110a;

        public static readonly int TX_TRAINING111a;

        public static readonly int TX_TRAINING112a;

        public static readonly int TX_TRAINING113a;

        public static readonly int TX_TRAINING114a;

        public static readonly int TX_TRAINING115a;

        public static readonly int TX_TRAINING116a;

        public static readonly int TX_TRAINING117a;

        public static readonly int TX_TRAINING118a;

        public static readonly int TX_TRAINING119a;

        public static readonly int TX_TRAINING120a;

        public static readonly int TX_TRAINING121a;

        public static readonly int TX_TRAINING122a;

        public static readonly int TX_TRAINING123a;

        public static readonly int TX_TRAINING201a;

        public static readonly int TX_TRAINING202a;

        public static readonly int TX_TRAINING203a;

        public static readonly int TX_TRAINING204a;

        public static readonly int TX_TRAINING205a;

        public static readonly int TX_TRAINING206a;

        public static readonly int TX_TRAINING207a;

        public static readonly int TX_TRAINING208a;

        public static readonly int TX_TRAINING209a;

        public static readonly int TX_TRAINING210a;

        public static readonly int TX_TRAINING301a;

        public static readonly int TX_TRAINING302a;

        public static readonly int TX_TRAINING303a;

        public static readonly int TX_TRAINING304a;

        public static readonly int TX_TRAINING305a;

        public static readonly int TX_TRAINING306a;

        public static readonly int TX_TRAINING307a;

        public static readonly int TX_TRAINING308a;

        public static readonly int TX_TRAINING309a;

        public static readonly int TX_TRAINING310a;

        public static readonly int TX_TRAINING311a;

        public static readonly int TX_TRAINING401a;

        public static readonly int TX_TRAINING402a;

        public static readonly int TX_TRAINING403a;

        public static readonly int TX_TRAINING404a;

        public static readonly int TX_TRAINING405a;

        public static readonly int TX_TRAINING406a;

        public static readonly int TX_TRAINING407a;

        public static readonly int TX_TRAINING408a;

        public static readonly int TX_TRAINING409a;

        public static readonly int TX_TRAINING410a;

        private static Dictionary<int, string> resources;

        public static string LoadString(int res)
        {
            string value;
            if (resources.TryGetValue(res, out value))
            {
                return value;
            }
            return "???";
        }

        static MyResource()
        {
            TX_BUTTON_PLAY = 100;
            TX_BUTTON_MENU = 101;
            TX_BUTTON_BACK = 102;
            TX_BUTTON_RESTART = 103;
            TX_BUTTON_CONTINUE = 104;
            TX_BUTTON_BUY = 105;
            TX_BUTTON_SETUP = 107;
            TX_BUTTON_SETUP_SOUNDS = 108;
            TX_BUTTON_SETUP_JUMP = 109;
            TX_BUTTON_SETUP_ZOOM = 110;
            TX_BUTTON_SETUP_ACCEL = 111;
            TX_BUTTON_SETUP_RESET = 112;
            TX_BUTTON_RANKING = 113;
            TX_GAMER_TITLE = 200;
            TX_GAMER_MDOORS = 201;
            TX_GAMER_SDOORS = 202;
            TX_GAMER_LIFES = 203;
            TX_TRIAL1 = 300;
            TX_TRIAL2 = 301;
            TX_TRIAL3 = 302;
            TX_TRIAL4 = 303;
            TX_TRIAL5 = 304;
            TX_TRIAL6 = 305;
            TX_TRAINING101 = 1000;
            TX_TRAINING102 = 1001;
            TX_TRAINING103 = 1002;
            TX_TRAINING104 = 1003;
            TX_TRAINING105 = 1004;
            TX_TRAINING106 = 1005;
            TX_TRAINING107 = 1006;
            TX_TRAINING108 = 1007;
            TX_TRAINING109 = 1008;
            TX_TRAINING110 = 1009;
            TX_TRAINING111 = 1010;
            TX_TRAINING112 = 1011;
            TX_TRAINING113 = 1012;
            TX_TRAINING114 = 1013;
            TX_TRAINING115 = 1014;
            TX_TRAINING116 = 1015;
            TX_TRAINING117 = 1016;
            TX_TRAINING118 = 1017;
            TX_TRAINING119 = 1018;
            TX_TRAINING120 = 1019;
            TX_TRAINING121 = 1020;
            TX_TRAINING122 = 1021;
            TX_TRAINING123 = 1022;
            TX_TRAINING201 = 2000;
            TX_TRAINING202 = 2001;
            TX_TRAINING203 = 2002;
            TX_TRAINING204 = 2003;
            TX_TRAINING205 = 2004;
            TX_TRAINING206 = 2005;
            TX_TRAINING207 = 2006;
            TX_TRAINING208 = 2007;
            TX_TRAINING209 = 2008;
            TX_TRAINING210 = 2009;
            TX_TRAINING301 = 3000;
            TX_TRAINING302 = 3001;
            TX_TRAINING303 = 3002;
            TX_TRAINING304 = 3003;
            TX_TRAINING305 = 3004;
            TX_TRAINING306 = 3005;
            TX_TRAINING307 = 3006;
            TX_TRAINING308 = 3007;
            TX_TRAINING309 = 3008;
            TX_TRAINING310 = 3009;
            TX_TRAINING311 = 3010;
            TX_TRAINING401 = 4000;
            TX_TRAINING402 = 4001;
            TX_TRAINING403 = 4002;
            TX_TRAINING404 = 4003;
            TX_TRAINING405 = 4004;
            TX_TRAINING406 = 4005;
            TX_TRAINING407 = 4006;
            TX_TRAINING408 = 4007;
            TX_TRAINING409 = 4008;
            TX_TRAINING410 = 4009;
            TX_TRAINING101a = 11000;
            TX_TRAINING102a = 11001;
            TX_TRAINING103a = 11002;
            TX_TRAINING104a = 11003;
            TX_TRAINING105a = 11004;
            TX_TRAINING106a = 11005;
            TX_TRAINING107a = 11006;
            TX_TRAINING108a = 11007;
            TX_TRAINING109a = 11008;
            TX_TRAINING110a = 11009;
            TX_TRAINING111a = 11010;
            TX_TRAINING112a = 11011;
            TX_TRAINING113a = 11012;
            TX_TRAINING114a = 11013;
            TX_TRAINING115a = 11014;
            TX_TRAINING116a = 11015;
            TX_TRAINING117a = 11016;
            TX_TRAINING118a = 11017;
            TX_TRAINING119a = 11018;
            TX_TRAINING120a = 11019;
            TX_TRAINING121a = 11020;
            TX_TRAINING122a = 11021;
            TX_TRAINING123a = 11022;
            TX_TRAINING201a = 12000;
            TX_TRAINING202a = 12001;
            TX_TRAINING203a = 12002;
            TX_TRAINING204a = 12003;
            TX_TRAINING205a = 12004;
            TX_TRAINING206a = 12005;
            TX_TRAINING207a = 12006;
            TX_TRAINING208a = 12007;
            TX_TRAINING209a = 12008;
            TX_TRAINING210a = 12009;
            TX_TRAINING301a = 13000;
            TX_TRAINING302a = 13001;
            TX_TRAINING303a = 13002;
            TX_TRAINING304a = 13003;
            TX_TRAINING305a = 13004;
            TX_TRAINING306a = 13005;
            TX_TRAINING307a = 13006;
            TX_TRAINING308a = 13007;
            TX_TRAINING309a = 13008;
            TX_TRAINING310a = 13009;
            TX_TRAINING311a = 13010;
            TX_TRAINING401a = 14000;
            TX_TRAINING402a = 14001;
            TX_TRAINING403a = 14002;
            TX_TRAINING404a = 14003;
            TX_TRAINING405a = 14004;
            TX_TRAINING406a = 14005;
            TX_TRAINING407a = 14006;
            TX_TRAINING408a = 14007;
            TX_TRAINING409a = 14008;
            TX_TRAINING410a = 14009;
            resources = new Dictionary<int, string>();
            string text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower();
            string text2;
            if ((text2 = text) != null && text2 == "fr")
            {
                InitializeFR();
            }
            else
            {
                InitializeEN();
            }
        }

        private static void InitializeFR()
        {
            resources.Add(TX_BUTTON_PLAY, "Jouer");
            resources.Add(TX_BUTTON_MENU, "Menu");
            resources.Add(TX_BUTTON_BACK, "Retour");
            resources.Add(TX_BUTTON_RESTART, "Recommencer");
            resources.Add(TX_BUTTON_CONTINUE, "Continuer");
            resources.Add(TX_BUTTON_BUY, "Acheter");
            resources.Add(TX_BUTTON_RANKING, "Classement");
            resources.Add(TX_BUTTON_SETUP, "Réglages");
            resources.Add(TX_BUTTON_SETUP_SOUNDS, "Bruitages");
            resources.Add(TX_BUTTON_SETUP_JUMP, "Bouton de saut à droite");
            resources.Add(TX_BUTTON_SETUP_ZOOM, "Zoom automatique sur l'action");
            resources.Add(TX_BUTTON_SETUP_ACCEL, "Accéléromètre");
            resources.Add(TX_BUTTON_SETUP_RESET, "Joueur {0} :\nEffacer la progression");
            resources.Add(TX_GAMER_TITLE, "Joueur {0}");
            resources.Add(TX_GAMER_MDOORS, "Portes principales : {0}/12");
            resources.Add(TX_GAMER_SDOORS, "Portes secondaires : {0}/52");
            resources.Add(TX_GAMER_LIFES, "Blupi : {0}");
            resources.Add(TX_TRIAL1, "Achetez la version complète");
            resources.Add(TX_TRIAL2, "\u000e 64 niveaux passionnants");
            resources.Add(TX_TRIAL3, "\u000e Des décors variés");
            resources.Add(TX_TRIAL4, "\u000e Une difficulté progressive");
            resources.Add(TX_TRIAL5, "\u000e De nouveaux pièges");
            resources.Add(TX_TRIAL6, "\u000e Un challenge fun");
            resources.Add(TX_TRAINING101, "Utilise la roue directionnelle \0.");
            resources.Add(TX_TRAINING102, "Appuie maintenant sur Saut \b.");
            resources.Add(TX_TRAINING103, "Appuie à droite sur la roue directionnelle \0 et sur Saut \b.");
            resources.Add(TX_TRAINING104, "Appuie sur Droite \0 et Saut \b.");
            resources.Add(TX_TRAINING105, "Essaie de ne pas te mouiller avec \0 \b !");
            resources.Add(TX_TRAINING106, "");
            resources.Add(TX_TRAINING107, "Prend l'ascenseur calmement, sans sauter \0.");
            resources.Add(TX_TRAINING108, "Saute sur l'ascenseur.");
            resources.Add(TX_TRAINING109, "");
            resources.Add(TX_TRAINING110, "Avance sans sauter et sans t'arrêter \0 !");
            resources.Add(TX_TRAINING111, "");
            resources.Add(TX_TRAINING112, "");
            resources.Add(TX_TRAINING113, "Avance sur la plateforme \0.");
            resources.Add(TX_TRAINING114, "Quitte la plateforme \0.");
            resources.Add(TX_TRAINING115, "Encore une fois, mais plus vite...");
            resources.Add(TX_TRAINING116, "Avance sur la plateforme \0 puis saute \0 \b.");
            resources.Add(TX_TRAINING117, "Saute lorsque tu es sur la plateforme \0 \b.");
            resources.Add(TX_TRAINING118, "Passe par en haut \0 \b.");
            resources.Add(TX_TRAINING119, "Les oeufs te redonnent des vies.");
            resources.Add(TX_TRAINING120, "Arrivé en haut, avance sur l'autre plateforme sans tarder...");
            resources.Add(TX_TRAINING121, "Attrape le deuxième et dernier trésor.");
            resources.Add(TX_TRAINING122, "Pour terminer, va sur la flèche rouge.");
            resources.Add(TX_TRAINING201, "Pousse la caisse sur le point rouge avec \0.");
            resources.Add(TX_TRAINING202, "Pratique, cette caisse, non ?");
            resources.Add(TX_TRAINING203, "Tire la caisse sur le point rouge avec \u0003.");
            resources.Add(TX_TRAINING204, "Empile les 2 caisses sur le point rouge pour passer.");
            resources.Add(TX_TRAINING205, "Empile 3 caisses sur le point rouge pour passer.");
            resources.Add(TX_TRAINING206, "");
            resources.Add(TX_TRAINING207, "");
            resources.Add(TX_TRAINING208, "");
            resources.Add(TX_TRAINING209, "");
            resources.Add(TX_TRAINING210, "");
            resources.Add(TX_TRAINING301, "Prend un hélico avec \t.");
            resources.Add(TX_TRAINING302, "Utilise \u0006 ou \b pour décoller. Dirige avec \u0004 et \0.");
            resources.Add(TX_TRAINING303, "Quitte l'hélico avec \t, il n'aime pas l'eau !");
            resources.Add(TX_TRAINING304, "Plonge. Utilise \u0004 \0 \u0002 \u0006 pour te diriger.");
            resources.Add(TX_TRAINING305, "Prend un hélico \t puis décole avec \u0006 ou \b.");
            resources.Add(TX_TRAINING306, "Attrape les 3 trésors puis monte.");
            resources.Add(TX_TRAINING307, "Pour passer, va chercher un skate en haut à gauche.");
            resources.Add(TX_TRAINING308, "Prend un skate avec \t.");
            resources.Add(TX_TRAINING309, "Tu peux passer sans crainte avec ton skate \0.");
            resources.Add(TX_TRAINING310, "Ton skate n'aime pas l'eau ! Utilise \0 \b.");
            resources.Add(TX_TRAINING311, "Pose ton skate avec \t.");
            resources.Add(TX_TRAINING401, "Prend la dynamite avec \t.");
            resources.Add(TX_TRAINING402, "Ne pose surtout pas la dynamite ici avec \t !");
            resources.Add(TX_TRAINING403, "Va chercher de la dynamite à gauche.");
            resources.Add(TX_TRAINING404, "Pose la dynamite avec \t, puis barre-toi !");
            resources.Add(TX_TRAINING405, "Pose encore de la dynamite pour passer.");
            resources.Add(TX_TRAINING406, "");
            resources.Add(TX_TRAINING407, "");
            resources.Add(TX_TRAINING408, "");
            resources.Add(TX_TRAINING409, "");
            resources.Add(TX_TRAINING410, "");
            resources.Add(TX_TRAINING101a, "Incline le téléphone à droite \v.");
            resources.Add(TX_TRAINING102a, "Appuie maintenant sur Saut \b.");
            resources.Add(TX_TRAINING103a, "\v et appuie sur Saut \b.");
            resources.Add(TX_TRAINING104a, "\v et Saut \b.");
            resources.Add(TX_TRAINING105a, "Essaie de ne pas te mouiller avec \v \b !");
            resources.Add(TX_TRAINING106a, "");
            resources.Add(TX_TRAINING107a, "Prend l'ascenseur calmement, sans sauter \v.");
            resources.Add(TX_TRAINING108a, "Saute sur l'ascenseur.");
            resources.Add(TX_TRAINING109a, "");
            resources.Add(TX_TRAINING110a, "Avance sans sauter et sans t'arrêter \v !");
            resources.Add(TX_TRAINING111a, "");
            resources.Add(TX_TRAINING112a, "");
            resources.Add(TX_TRAINING113a, "Avance sur la plateforme \v.");
            resources.Add(TX_TRAINING114a, "Quitte la plateforme \v.");
            resources.Add(TX_TRAINING115a, "Encore une fois, mais plus vite...");
            resources.Add(TX_TRAINING116a, "Avance sur la plateforme \v puis saute \v \b.");
            resources.Add(TX_TRAINING117a, "Saute lorsque tu es sur la plateforme \v \b.");
            resources.Add(TX_TRAINING118a, "Passe par en haut \v \b.");
            resources.Add(TX_TRAINING119a, "Les oeufs te redonnent des vies.");
            resources.Add(TX_TRAINING120a, "Arrivé en haut, avance sur l'autre plateforme sans tarder...");
            resources.Add(TX_TRAINING121a, "Attrape le deuxième et dernier trésor.");
            resources.Add(TX_TRAINING122a, "Pour terminer, va sur la flèche rouge.");
            resources.Add(TX_TRAINING201a, "Pousse la caisse sur le point rouge avec \v.");
            resources.Add(TX_TRAINING202a, "Pratique, cette caisse, non ?");
            resources.Add(TX_TRAINING203a, "Tire la caisse sur le point rouge avec \f et \n.");
            resources.Add(TX_TRAINING204a, "Empile les 2 caisses sur le point rouge pour passer.");
            resources.Add(TX_TRAINING205a, "Empile 3 caisses sur le point rouge pour passer.");
            resources.Add(TX_TRAINING206a, "");
            resources.Add(TX_TRAINING207a, "");
            resources.Add(TX_TRAINING208a, "");
            resources.Add(TX_TRAINING209a, "");
            resources.Add(TX_TRAINING210a, "");
            resources.Add(TX_TRAINING301a, "Prend un hélico avec \t.");
            resources.Add(TX_TRAINING302a, "Utilise \b pour décoller. Dirige avec \f et \v.");
            resources.Add(TX_TRAINING303a, "Quitte l'hélico avec \t, il n'aime pas l'eau !");
            resources.Add(TX_TRAINING304a, "Plonge. Utilise \f \v \b \n pour te diriger.");
            resources.Add(TX_TRAINING305a, "Prend un hélico \t puis décole avec \b.");
            resources.Add(TX_TRAINING306a, "Attrape les 3 trésors puis monte.");
            resources.Add(TX_TRAINING307a, "Pour passer, va chercher un skate en haut à gauche.");
            resources.Add(TX_TRAINING308a, "Prend un skate avec \t.");
            resources.Add(TX_TRAINING309a, "Tu peux passer sans crainte avec ton skate \v.");
            resources.Add(TX_TRAINING310a, "Ton skate n'aime pas l'eau ! Utilise \v \b.");
            resources.Add(TX_TRAINING311a, "Pose ton skate avec \t.");
            resources.Add(TX_TRAINING401a, "Prend la dynamite avec \t.");
            resources.Add(TX_TRAINING402a, "Ne pose surtout pas la dynamite ici avec \t !");
            resources.Add(TX_TRAINING403a, "Va chercher de la dynamite à gauche.");
            resources.Add(TX_TRAINING404a, "Pose la dynamite avec \t, puis barre-toi !");
            resources.Add(TX_TRAINING405a, "Pose encore de la dynamite pour passer.");
            resources.Add(TX_TRAINING406a, "");
            resources.Add(TX_TRAINING407a, "");
            resources.Add(TX_TRAINING408a, "");
            resources.Add(TX_TRAINING409a, "");
            resources.Add(TX_TRAINING410a, "");
        }

        private static void InitializeEN()
        {
            resources.Add(TX_BUTTON_PLAY, "Play");
            resources.Add(TX_BUTTON_MENU, "Home");
            resources.Add(TX_BUTTON_BACK, "Back");
            resources.Add(TX_BUTTON_RESTART, "Restart");
            resources.Add(TX_BUTTON_CONTINUE, "Continue");
            resources.Add(TX_BUTTON_BUY, "Buy");
            resources.Add(TX_BUTTON_RANKING, "Ranking");
            resources.Add(TX_BUTTON_SETUP, "Setup");
            resources.Add(TX_BUTTON_SETUP_SOUNDS, "Sound effects");
            resources.Add(TX_BUTTON_SETUP_JUMP, "Jump button on the right");
            resources.Add(TX_BUTTON_SETUP_ZOOM, "Automatic zoom on action");
            resources.Add(TX_BUTTON_SETUP_ACCEL, "Accelerometer");
            resources.Add(TX_BUTTON_SETUP_RESET, "Player {0} :\nErase progress");
            resources.Add(TX_GAMER_TITLE, "Player {0}");
            resources.Add(TX_GAMER_MDOORS, "Main gates : {0}/12");
            resources.Add(TX_GAMER_SDOORS, "Secondary gates : {0}/52");
            resources.Add(TX_GAMER_LIFES, "Blupi : {0}");
            resources.Add(TX_TRIAL1, "Buy the full version");
            resources.Add(TX_TRIAL2, "\u000e 64 exciting stages");
            resources.Add(TX_TRIAL3, "\u000e Varied backgrounds");
            resources.Add(TX_TRIAL4, "\u000e An increasing difficulty");
            resources.Add(TX_TRIAL5, "\u000e New traps");
            resources.Add(TX_TRIAL6, "\u000e Challenge and fun");
            resources.Add(TX_TRAINING101, "Use the directional wheel \0.");
            resources.Add(TX_TRAINING102, "Press Jump \b.");
            resources.Add(TX_TRAINING103, "Press Right \0 and Jump \b.");
            resources.Add(TX_TRAINING104, "Press Right \0 and Jump \b.");
            resources.Add(TX_TRAINING105, "Don't fall into the water \0 \b !");
            resources.Add(TX_TRAINING106, "");
            resources.Add(TX_TRAINING107, "Take the elevator quietly, without jumping \0.");
            resources.Add(TX_TRAINING108, "Jump on the elevator.");
            resources.Add(TX_TRAINING109, "");
            resources.Add(TX_TRAINING110, "Move forward without jumping nor stopping \0 !");
            resources.Add(TX_TRAINING111, "");
            resources.Add(TX_TRAINING112, "");
            resources.Add(TX_TRAINING113, "Move forward on the platform \0.");
            resources.Add(TX_TRAINING114, "Leave the platform \0.");
            resources.Add(TX_TRAINING115, "Once again, but faster...");
            resources.Add(TX_TRAINING116, "Move forward on the platform \0, then jump \0 \b.");
            resources.Add(TX_TRAINING117, "Jump when you are on the platform \0 \b.");
            resources.Add(TX_TRAINING118, "Choose the upper path \0 \b.");
            resources.Add(TX_TRAINING119, "Eggs give you extra lives.");
            resources.Add(TX_TRAINING120, "Once on the top, move forward on the other platform without delay...");
            resources.Add(TX_TRAINING121, "Catch the second and last treasure.");
            resources.Add(TX_TRAINING122, "Join the red arrow.");
            resources.Add(TX_TRAINING201, "Push the box forward until the red dot with \0.");
            resources.Add(TX_TRAINING202, "Practical, right?");
            resources.Add(TX_TRAINING203, "Pull the box backward until the red dot with \u0003.");
            resources.Add(TX_TRAINING204, "Stack both boxes up on the red dot to move on.");
            resources.Add(TX_TRAINING205, "Stack the three boxes up on the red dot to move on.");
            resources.Add(TX_TRAINING206, "");
            resources.Add(TX_TRAINING207, "");
            resources.Add(TX_TRAINING208, "");
            resources.Add(TX_TRAINING209, "");
            resources.Add(TX_TRAINING210, "");
            resources.Add(TX_TRAINING301, "Take a helicopter with \t.");
            resources.Add(TX_TRAINING302, "Use \u0006 or \b to take off. Direct with \u0004 and \0.");
            resources.Add(TX_TRAINING303, "Leave the helicopter with \t, it dislikes water!");
            resources.Add(TX_TRAINING304, "Plunge. Use \u0004 \0 \u0002 \u0006 to direct.");
            resources.Add(TX_TRAINING305, "Take a helicopter \t then take off with \u0006 or \b.");
            resources.Add(TX_TRAINING306, "Grab the three treasures, then go up.");
            resources.Add(TX_TRAINING307, "Go and get a skate in the top left corner.");
            resources.Add(TX_TRAINING308, "Take a skate with \t.");
            resources.Add(TX_TRAINING309, "You can move on with your skate without fear \0.");
            resources.Add(TX_TRAINING310, "Your skate dislikes water! Jump!");
            resources.Add(TX_TRAINING311, "Leave your skate with \t.");
            resources.Add(TX_TRAINING401, "Take the dynamite sticks with \t.");
            resources.Add(TX_TRAINING402, "Do not put down the dynamite here!");
            resources.Add(TX_TRAINING403, "Go and get the dynamite sticks on the left.");
            resources.Add(TX_TRAINING404, "Put down the dynamite with \t, then clear off!");
            resources.Add(TX_TRAINING405, "Put down another stick of dynamite here to move on.");
            resources.Add(TX_TRAINING406, "");
            resources.Add(TX_TRAINING407, "");
            resources.Add(TX_TRAINING408, "");
            resources.Add(TX_TRAINING409, "");
            resources.Add(TX_TRAINING410, "");
            resources.Add(TX_TRAINING101a, "Tilt the phone \v.");
            resources.Add(TX_TRAINING102a, "Press Jump \b.");
            resources.Add(TX_TRAINING103a, "\v and Jump \b.");
            resources.Add(TX_TRAINING104a, "\v and Jump \b.");
            resources.Add(TX_TRAINING105a, "Don't fall into the water \v \b !");
            resources.Add(TX_TRAINING106a, "");
            resources.Add(TX_TRAINING107a, "Take the elevator quietly, without jumping \v.");
            resources.Add(TX_TRAINING108a, "Jump on the elevator.");
            resources.Add(TX_TRAINING109a, "");
            resources.Add(TX_TRAINING110a, "Move forward without jumping nor stopping \v !");
            resources.Add(TX_TRAINING111a, "");
            resources.Add(TX_TRAINING112a, "");
            resources.Add(TX_TRAINING113a, "Move forward on the platform \v.");
            resources.Add(TX_TRAINING114a, "Leave the platform \v.");
            resources.Add(TX_TRAINING115a, "Once again, but faster...");
            resources.Add(TX_TRAINING116a, "Move forward on the platform \v, then jump \v \b.");
            resources.Add(TX_TRAINING117a, "Jump when you are on the platform \v \b.");
            resources.Add(TX_TRAINING118a, "Choose the upper path \v \b.");
            resources.Add(TX_TRAINING119a, "Eggs give you extra lives.");
            resources.Add(TX_TRAINING120a, "Once on the top, move forward on the other platform without delay...");
            resources.Add(TX_TRAINING121a, "Catch the second and last treasure.");
            resources.Add(TX_TRAINING122a, "Join the red arrow.");
            resources.Add(TX_TRAINING201a, "Push the box forward until the red dot with \v.");
            resources.Add(TX_TRAINING202a, "Practical, right?");
            resources.Add(TX_TRAINING203a, "Pull the box backward until the red dot with \f and \n.");
            resources.Add(TX_TRAINING204a, "Stack both boxes up on the red dot to move on.");
            resources.Add(TX_TRAINING205a, "Stack the three boxes up on the red dot to move on.");
            resources.Add(TX_TRAINING206a, "");
            resources.Add(TX_TRAINING207a, "");
            resources.Add(TX_TRAINING208a, "");
            resources.Add(TX_TRAINING209a, "");
            resources.Add(TX_TRAINING210a, "");
            resources.Add(TX_TRAINING301a, "Take a helicopter with \t.");
            resources.Add(TX_TRAINING302a, "Use \b to take off. Direct with \f and \v.");
            resources.Add(TX_TRAINING303a, "Leave the helicopter with \t, it dislikes water!");
            resources.Add(TX_TRAINING304a, "Plunge. Use \f \v \b \n to direct.");
            resources.Add(TX_TRAINING305a, "Take a helicopter \t then take off with \b.");
            resources.Add(TX_TRAINING306a, "Grab the three treasures, then go up.");
            resources.Add(TX_TRAINING307a, "Go and get a skate in the top left corner.");
            resources.Add(TX_TRAINING308a, "Take a skate with \t.");
            resources.Add(TX_TRAINING309a, "You can move on with your skate without fear \v.");
            resources.Add(TX_TRAINING310a, "Your skate dislikes water! Jump!");
            resources.Add(TX_TRAINING311a, "Leave your skate with \t.");
            resources.Add(TX_TRAINING401a, "Take the dynamite sticks with \t.");
            resources.Add(TX_TRAINING402a, "Do not put down the dynamite here!");
            resources.Add(TX_TRAINING403a, "Go and get the dynamite sticks on the left.");
            resources.Add(TX_TRAINING404a, "Put down the dynamite with \t, then clear off!");
            resources.Add(TX_TRAINING405a, "Put down another stick of dynamite here to move on.");
            resources.Add(TX_TRAINING406a, "");
            resources.Add(TX_TRAINING407a, "");
            resources.Add(TX_TRAINING408a, "");
            resources.Add(TX_TRAINING409a, "");
            resources.Add(TX_TRAINING410a, "");
        }

        private static void InitializeDE()
        {
            resources.Add(TX_BUTTON_PLAY, "Play");
            resources.Add(TX_BUTTON_MENU, "Home");
            resources.Add(TX_BUTTON_BACK, "Back");
            resources.Add(TX_BUTTON_RESTART, "Restart");
            resources.Add(TX_BUTTON_CONTINUE, "Continue");
            resources.Add(TX_BUTTON_BUY, "Buy");
            resources.Add(TX_BUTTON_RANKING, "Ranking");
            resources.Add(TX_BUTTON_SETUP, "Setup");
            resources.Add(TX_BUTTON_SETUP_SOUNDS, "Sounds");
            resources.Add(TX_BUTTON_SETUP_JUMP, "Jump button to the right");
            resources.Add(TX_BUTTON_SETUP_ZOOM, "Automatically zoom action");
            resources.Add(TX_BUTTON_SETUP_ACCEL, "Accelerometer");
            resources.Add(TX_BUTTON_SETUP_RESET, "Gamer {0} :\nReset progression");
            resources.Add(TX_GAMER_TITLE, "Gamer {0}");
            resources.Add(TX_GAMER_MDOORS, "Main doors : {0}/12");
            resources.Add(TX_GAMER_SDOORS, "Secondary doors : {0}/52");
            resources.Add(TX_GAMER_LIFES, "Blupi : {0}");
            resources.Add(TX_TRIAL1, "Buy the full version");
            resources.Add(TX_TRIAL2, "\u000e 64 niveaux passionnants");
            resources.Add(TX_TRIAL3, "\u000e Des décors variés");
            resources.Add(TX_TRIAL4, "\u000e Une difficulté progressive");
            resources.Add(TX_TRIAL5, "\u000e De nouveaux pièges");
            resources.Add(TX_TRIAL6, "\u000e Un challenge fun");
            resources.Add(TX_TRAINING101, "Utilise la roue directionnelle \0 pour faire avancer Blupi.");
            resources.Add(TX_TRAINING102, "Appuie maintenant sur le bouton de saut \b.");
            resources.Add(TX_TRAINING103, "Appuie à droite sur la roue directionnelle \0 et sur Saut \b.");
            resources.Add(TX_TRAINING104, "Appuie sur Droite \0 et Saut \b.");
            resources.Add(TX_TRAINING105, "Essaie de ne pas te mouiller avec \0 \b !");
            resources.Add(TX_TRAINING106, "");
            resources.Add(TX_TRAINING107, "Prend l'ascenseur calmement, sans sauter \0.");
            resources.Add(TX_TRAINING108, "Saute sur l'ascenseur.");
            resources.Add(TX_TRAINING109, "");
            resources.Add(TX_TRAINING110, "Avance sans sauter et sans t'arrêter \0 !");
            resources.Add(TX_TRAINING111, "");
            resources.Add(TX_TRAINING112, "");
            resources.Add(TX_TRAINING113, "Avance sur la plateforme \0.");
            resources.Add(TX_TRAINING114, "Quitte la plateforme \0.");
            resources.Add(TX_TRAINING115, "Encore une fois, mais plus vite...");
            resources.Add(TX_TRAINING116, "Avance sur la plateforme \0 puis saute \0 \b.");
            resources.Add(TX_TRAINING117, "Saute lorsque tu es sur la plateforme \0 \b.");
            resources.Add(TX_TRAINING118, "Passe par en haut \0 \b.");
            resources.Add(TX_TRAINING119, "Les oeufs te redonnent des vies.");
            resources.Add(TX_TRAINING120, "Arrivé en haut, avance sur l'autre plateforme sans tarder...");
            resources.Add(TX_TRAINING121, "Attrape le deuxième et dernier trésor.");
            resources.Add(TX_TRAINING122, "Pour terminer, va sur la flèche rouge.");
            resources.Add(TX_TRAINING201, "Pousse la caisse sur le point rouge avec \0.");
            resources.Add(TX_TRAINING202, "Utilise la caisse pour passer l'obstacle avec \0 \b.");
            resources.Add(TX_TRAINING203, "Tire la caisse sur le point rouge avec \u0003.");
            resources.Add(TX_TRAINING204, "Empile les 2 caisses sur le point rouge pour passer.");
            resources.Add(TX_TRAINING205, "Empile 3 caisses sur le point rouge pour passer.");
            resources.Add(TX_TRAINING206, "");
            resources.Add(TX_TRAINING207, "");
            resources.Add(TX_TRAINING208, "");
            resources.Add(TX_TRAINING209, "");
            resources.Add(TX_TRAINING210, "");
            resources.Add(TX_TRAINING301, "Prend un hélico avec \t.");
            resources.Add(TX_TRAINING302, "Utilise \u0006 ou \b pour décoler. Dirige avec \u0004 et \0.");
            resources.Add(TX_TRAINING303, "Quitte l'hélico avec \t, il n'aime pas l'eau !");
            resources.Add(TX_TRAINING304, "Plonge. Utilise \u0004 \0 \u0002 \u0006 pour te diriger.");
            resources.Add(TX_TRAINING305, "Prend un hélico \t puis décole avec \u0006 ou \b.");
            resources.Add(TX_TRAINING306, "Attrape les 3 trésors puis monte.");
            resources.Add(TX_TRAINING307, "Pour passer, va chercher un skate en haut à gauche.");
            resources.Add(TX_TRAINING308, "Prend un skate avec \t.");
            resources.Add(TX_TRAINING309, "Tu peux passer sans crainte avec ton skate \0.");
            resources.Add(TX_TRAINING310, "Ton skate n'aime pas l'eau ! Utilise \0 \b.");
            resources.Add(TX_TRAINING311, "Pose ton skate avec \t.");
            resources.Add(TX_TRAINING401, "Prend la dynamite avec \t.");
            resources.Add(TX_TRAINING402, "Ne pose surtout pas la dynamite ici avec \t !");
            resources.Add(TX_TRAINING403, "Va chercher de la dynamite à gauche.");
            resources.Add(TX_TRAINING404, "Pose la dynamite avec \t, puis barre-toi !");
            resources.Add(TX_TRAINING405, "Pose encore de la dynamite pour passer.");
            resources.Add(TX_TRAINING406, "");
            resources.Add(TX_TRAINING407, "");
            resources.Add(TX_TRAINING408, "");
            resources.Add(TX_TRAINING409, "");
            resources.Add(TX_TRAINING410, "");
        }
    }
}