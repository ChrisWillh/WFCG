﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarhammerFantasyCharGen
{
    public partial class WarhammerFantasyCharGen : Form
    {
        int marked = 0;

        public WarhammerFantasyCharGen()
        {
            InitializeComponent();

            characterGen();
        }

        public void characterGen()
        {
            //Load race based lists
            loadRace();
            
            //roll stats
            statsRoll();

            //Pick Career
            careerRoll();
            
            //pick eye color
            eyeColorRoll();
            
            //pick hair color
            hairColorRoll();
            
            //pick weight
            weightRoll();
            
            //pick Height
            heightRoll();

            //roll for distinguishing mark
            markRoll();

            //Roll for number of siblings
            siblingsRoll();

            //roll for age
            ageRoll();
        }

        public void loadRace()
        {
            cbCareer.Items.Clear();
            cbEyeColor.Items.Clear();
            cbHairColor.Items.Clear();

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    cbCareer.Items.AddRange(new object[] {
                    "Agitator",
                    "Bodyguard",
                    "Burgher",
                    "Coachman",
                    "Entertainer",
                    "Hunter",
                    "Jailer",
                    "Marine",
                    "Mercenary",
                    "Militiaman",
                    "Miner",
                    "Noble",
                    "Outlaw",
                    "Pit Fighter",
                    "Protogonist",
                    "Rat Catcher",
                    "Runebearer",
                    "Scribe",
                    "Seaman",
                    "Servant",
                    "Shieldbreaker",
                    "Smuggler",
                    "Soldier",
                    "Student",
                    "Thief",
                    "Toll Keeper",
                    "Tomb Robber",
                    "Traidsman",
                    "Troll Slayer",
                    "Watchman"});

                    cbEyeColor.Items.AddRange(new object[] {
                    "Pale Grey",
                    "Blue",
                    "Copper",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Purple"});

                    cbHairColor.Items.AddRange(new object[] {
                    "Ash Blond",
                    "Yellow",
                    "Red",
                    "Copper",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Blue Black",
                    "Black"}); 
                    break;
                case 1:
                    cbEyeColor.Items.AddRange(new object[] {
                    "Grey Blue",
                    "Blue",
                    "Green",
                    "Copper",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Silver",
                    "Purple",
                    "Black"});
                    
                    cbHairColor.Items.AddRange(new object[] {
                    "Silver",
                    "Ash Blond",
                    "Corn",
                    "Yellow",
                    "Copper",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Black"});

                    cbCareer.Items.AddRange(new object[] {
                    "Apprentice Wizard",
                    "Entertainer",
                    "Envoy",
                    "Hunter",
                    "Kithband Warrior",
                    "Mercenary",
                    "Messenger",
                    "Outlaw",
                    "Outrider",
                    "Rogue",
                    "Scribe",
                    "Seaman",
                    "Student",
                    "Thief",
                    "Traidsman",
                    "Vagabond"});
                    break;
                case 2:
                    cbEyeColor.Items.AddRange(new object[] {
                    "Blue",
                    "Hazel",
                    "Light Brown",
                    "Brown",
                    "Dark Brown"});
                    
                    cbHairColor.Items.AddRange(new object[] {
                    "Ash Blond",
                    "Corn",
                    "Yellow",
                    "Copper",
                    "Red",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Black"});

                    cbCareer.Items.AddRange(new object[] {
                    "Agitator",
                    "Barber-Surgeon",
                    "Bone Picker",
                    "Bounty Hunter",
                    "Burgher",
                    "Camp Follower",
                    "Charcoal-Burner",
                    "Entertainer",
                    "Ferryman",
                    "Fieldwarden",
                    "Fisherman",
                    "Grave Robber",
                    "Hunter",
                    "Mercenary",
                    "Messenger",
                    "Militiaman",
                    "Outlaw",
                    "Peasant",
                    "Rat Catcher",
                    "Rogue",
                    "Servant",
                    "Smuggler",
                    "Soldier",
                    "Student",
                    "Thief",
                    "Toll Keeper",
                    "Tomb Robber",
                    "Traidsman",
                    "Vagabond",
                    "Valet",
                    "Watchman"});
                    break;
                case 3:
                    cbEyeColor.Items.AddRange(new object[] {
                    "Pale Grey",
                    "Grey Blue",
                    "Blue",
                    "Green",
                    "Copper",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Purple",
                    "Black"});

                    cbHairColor.Items.AddRange(new object[] {
                    "Ash Blond",
                    "Corn",
                    "Yellow",
                    "Copper",
                    "Red",
                    "Light Brown",
                    "Brown",
                    "Dark Brown",
                    "Black"});

                    cbCareer.Items.AddRange(new object[] {
                    "Agitator",
                    "Apprentice Wizard",
                    "Bailiff",
                    "Barber-Surgeon",
                    "Boatman",
                    "Bodyguard",
                    "Bone Picker",
                    "Bounty Hunter",
                    "Burgher",
                    "Camp Follower",
                    "Charcoal-Burner",
                    "Coachman",
                    "Entertainer",
                    "Estalian Diestro",
                    "Ferryman",
                    "Fisherman",
                    "Grave Robber",
                    "Hedge Wizard",
                    "Hunter",
                    "Initiate",
                    "Jailer",
                    "Kislevite Kossar",
                    "Marine",
                    "Mercenary",
                    "Messenger",
                    "Militiaman",
                    "Miner",
                    "Noble",
                    "Norse Berserker",
                    "Outlaw",
                    "Outrider",
                    "Peasant",
                    "Pit Fighter",
                    "Protagonist",
                    "Rat Catcher",
                    "Roadwarden",
                    "Rogue",
                    "Scribe",
                    "Seaman",
                    "Servant",
                    "Smuggler",
                    "Soldier",
                    "Squire",
                    "Student",
                    "Thief",
                    "Thug",
                    "Toll Keeper",
                    "Tomb Robber",
                    "Traidsman",
                    "Vagabond",
                    "Valet",
                    "Watchman",
                    "Woodsman",
                    "Zealot"});
                    break;
            }
        }

        public void statsRoll()
        {
            var r = new Random();
            int woundsRoll = r.Next(1, 10);
            int fateRoll = r.Next(1, 10);
            int WSBase = 20;
            int BSBase = 20;
            int SBase = 20;
            int TBase = 20;
            int AgBase = 20;
            int IntBase = 20;
            int WPBase = 20;
            int FelBase = 20;
            int wound1 = 10;
            int wound2 = 10;
            int wound3 = 10;
            int wound4 = 10;
            int fate1 = 1;
            int fate2 = 1;
            int fate3 = 1;

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    WSBase = 30;
                    BSBase = 20;
                    SBase = 20;
                    TBase = 30;
                    AgBase = 10;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 10;
                    wound1 = 11;
                    wound2 = 12;
                    wound3 = 13;
                    wound4 = 14;
                    fate1 = 1;
                    fate2 = 2;
                    fate3 = 3;
                    break;
                case 1:
                    WSBase = 20;
                    BSBase = 30;
                    SBase = 20;
                    TBase = 20;
                    AgBase = 30;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 20;
                    wound1 = 9;
                    wound2 = 10;
                    wound3 = 11;
                    wound4 = 12;
                    fate1 = 1;
                    fate2 = 2;
                    fate3 = 2;
                    break;
                case 2:
                    WSBase = 10;
                    BSBase = 30;
                    SBase = 10;
                    TBase = 10;
                    AgBase = 30;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 30;
                    wound1 = 8;
                    wound2 = 9;
                    wound3 = 10;
                    wound4 = 11;
                    fate1 = 2;
                    fate2 = 2;
                    fate3 = 3;
                    break;
                case 3:
                    WSBase = 20;
                    BSBase = 20;
                    SBase = 20;
                    TBase = 20;
                    AgBase = 20;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 20;
                    wound1 = 10;
                    wound2 = 11;
                    wound3 = 12;
                    wound4 = 13;
                    fate1 = 2;
                    fate2 = 3;
                    fate3 = 3;
                    break;
            }

            txWeaponSkilStart.Text = Convert.ToString(WSBase + r.Next(2, 20));
            txBalisticSkilStart.Text = Convert.ToString(BSBase + r.Next(2, 20));
            txStrentghStart.Text = Convert.ToString(SBase + r.Next(2, 20));
            txToughnesStart.Text = Convert.ToString(TBase + r.Next(2, 20));
            txAgilityStart.Text = Convert.ToString(AgBase + r.Next(2, 20));
            txIntStart.Text = Convert.ToString(IntBase + r.Next(2, 20));
            txWillStart.Text = Convert.ToString(WPBase + r.Next(2, 20));
            txFellowStart.Text = Convert.ToString(FelBase + r.Next(2, 20));

            switch (r.Next(1, 10))
            {
                case 1:
                case 2:
                case 3:
                    txWoundsStart.Text = Convert.ToString(wound1);
                    break;
                case 4:
                case 5:
                case 6:
                    txWoundsStart.Text = Convert.ToString(wound2);
                    break;
                case 7:
                case 8:
                case 9:
                    txWoundsStart.Text = Convert.ToString(wound3);
                    break;
                case 10:
                    txWoundsStart.Text = Convert.ToString(wound4);
                    break;
            }

            txStrBonusStart.Text = Convert.ToString(Convert.ToInt32(txStrentghStart.Text) / 10);
            txToughBonusStart.Text = Convert.ToString(Convert.ToInt32(txToughnesStart.Text) / 10);

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    txMoveStart.Text = "3";
                    break;
                case 1:
                    txMoveStart.Text = "5";
                    break;
                case 2:
                    txMoveStart.Text = "4";
                    break;
                case 3:
                    txMoveStart.Text = "4";
                    break;
            }

            switch (r.Next(1, 10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    txFateStart.Text = Convert.ToString(fate1);
                    break;
                case 5:
                case 6:
                case 7:
                    txFateStart.Text = Convert.ToString(fate2);
                    break;
                case 8:
                case 9:
                case 10:
                    txFateStart.Text = Convert.ToString(fate3);
                    break;
            }
        }

        public void careerRoll()
        {
            var r = new Random();
            int careerPick = r.Next(1, 100);

            switch(cbRace.SelectedIndex)
            {
                case 0:
                    if (careerPick >= 1 && careerPick <= 2)
                    { cbCareer.SelectedIndex = 0; }
                    else if (careerPick >= 3 && careerPick <= 6)
                    { cbCareer.SelectedIndex = 1; }
                    else if (careerPick >= 7 && careerPick <= 10)
                    { cbCareer.SelectedIndex = 2; }
                    else if (careerPick >= 11 && careerPick <= 12)
                    { cbCareer.SelectedIndex = 3; }
                    else if (careerPick >= 13 && careerPick <= 15)
                    { cbCareer.SelectedIndex = 4; }
                    else if (careerPick >= 16 && careerPick <= 19)
                    { cbCareer.SelectedIndex = 5; }
                    else if (careerPick >= 20 && careerPick <= 23)
                    { cbCareer.SelectedIndex = 6; }
                    else if (careerPick == 24)
                    { cbCareer.SelectedIndex = 7; }
                    else if (careerPick >= 25 && careerPick <= 30)
                    { cbCareer.SelectedIndex = 8; }
                    else if (careerPick >= 31 && careerPick <= 34)
                    { cbCareer.SelectedIndex = 9; }
                    else if (careerPick >= 35 && careerPick <= 40)
                    { cbCareer.SelectedIndex = 10; }
                    else if (careerPick >= 41 && careerPick <= 42)
                    { cbCareer.SelectedIndex = 11; }
                    else if (careerPick >= 43 && careerPick <= 45)
                    { cbCareer.SelectedIndex = 12; }
                    else if (careerPick >= 46 && careerPick <= 50)
                    { cbCareer.SelectedIndex = 13; }
                    else if (careerPick >= 51 && careerPick <= 54)
                    { cbCareer.SelectedIndex = 14; }
                    else if (careerPick >= 55 && careerPick <= 58)
                    { cbCareer.SelectedIndex = 15; }
                    else if (careerPick >= 59 && careerPick <= 63)
                    { cbCareer.SelectedIndex = 16; }
                    else if (careerPick >= 64 && careerPick <= 65)
                    { cbCareer.SelectedIndex = 17; }
                    else if (careerPick == 66)
                    { cbCareer.SelectedIndex = 18; }
                    else if (careerPick >= 67 && careerPick <= 68)
                    { cbCareer.SelectedIndex = 19; }
                    else if (careerPick >= 69 && careerPick <= 72)
                    { cbCareer.SelectedIndex = 20; }
                    else if (careerPick >= 73 && careerPick <= 75)
                    { cbCareer.SelectedIndex = 21; }
                    else if (careerPick >= 76 && careerPick <= 79)
                    { cbCareer.SelectedIndex = 22; }
                    else if (careerPick >= 80 && careerPick <= 81)
                    { cbCareer.SelectedIndex = 23; }
                    else if (careerPick >= 82 && careerPick <= 84)
                    { cbCareer.SelectedIndex = 24; }
                    else if (careerPick >= 85 && careerPick <= 87)
                    { cbCareer.SelectedIndex = 25; }
                    else if (careerPick >= 88 && careerPick <= 90)
                    { cbCareer.SelectedIndex = 26; }
                    else if (careerPick >= 91 && careerPick <= 94)
                    { cbCareer.SelectedIndex = 27; }
                    else if (careerPick >= 95 && careerPick <= 98)
                    { cbCareer.SelectedIndex = 28; }
                    else if (careerPick >= 99 && careerPick <= 100)
                    { cbCareer.SelectedIndex = 29; }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public void weightRoll()
        {
            var r = new Random();
            int weightRoll = r.Next(1, 100);

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    if (weightRoll == 1)
                    { txWeight.Text = "90"; }
                    else if (weightRoll >= 2 && weightRoll <= 3)
                    { txWeight.Text = "95"; }
                    else if (weightRoll >= 4 && weightRoll <= 5)
                    { txWeight.Text = "100"; }
                    else if (weightRoll >= 6 && weightRoll <= 8)
                    { txWeight.Text = "105"; }
                    else if (weightRoll >= 9 && weightRoll <= 12)
                    { txWeight.Text = "110"; }
                    else if (weightRoll >= 13 && weightRoll <= 17)
                    { txWeight.Text = "115"; }
                    else if (weightRoll >= 18 && weightRoll <= 22)
                    { txWeight.Text = "120"; }
                    else if (weightRoll >= 23 && weightRoll <= 29)
                    { txWeight.Text = "125"; }
                    else if (weightRoll >= 30 && weightRoll <= 37)
                    { txWeight.Text = "130"; }
                    else if (weightRoll >= 38 && weightRoll <= 49)
                    { txWeight.Text = "135"; }
                    else if (weightRoll >= 50 && weightRoll <= 64)
                    { txWeight.Text = "140"; }
                    else if (weightRoll >= 65 && weightRoll <= 71)
                    { txWeight.Text = "145"; }
                    else if (weightRoll >= 72 && weightRoll <= 78)
                    { txWeight.Text = "150"; }
                    else if (weightRoll >= 79 && weightRoll <= 83)
                    { txWeight.Text = "155"; }
                    else if (weightRoll >= 84 && weightRoll <= 88)
                    { txWeight.Text = "160"; }
                    else if (weightRoll >= 89 && weightRoll <= 92)
                    { txWeight.Text = "165"; }
                    else if (weightRoll >= 93 && weightRoll <= 95)
                    { txWeight.Text = "170"; }
                    else if (weightRoll >= 96 && weightRoll <= 97)
                    { txWeight.Text = "175"; }
                    else if (weightRoll >= 98 && weightRoll <= 99)
                    { txWeight.Text = "180"; }
                    if (weightRoll == 100)
                    { txWeight.Text = "185"; }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public void eyeColorRoll()
        {
            var r = new Random();
            int eyePick = r.Next(1, 10);

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    if (eyePick == 1)
                    { cbEyeColor.SelectedIndex = 0; }
                    else if (eyePick == 2)
                    { cbEyeColor.SelectedIndex = 1; }
                    else if (eyePick == 3)
                    { cbEyeColor.SelectedIndex = 2; }
                    else if (eyePick >= 4 && eyePick <= 5)
                    { cbEyeColor.SelectedIndex = 3; }
                    else if (eyePick >= 6 && eyePick <= 7)
                    { cbEyeColor.SelectedIndex = 4; }
                    else if (eyePick >= 8 && eyePick <= 9)
                    { cbEyeColor.SelectedIndex = 5; }
                    else if (eyePick == 10)
                    { cbEyeColor.SelectedIndex = 6; }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public void hairColorRoll()
        {
            var r = new Random(); 
            int hairPick = r.Next(1, 10);

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    if (hairPick == 1)
                    { cbHairColor.SelectedIndex = 0; }
                    else if (hairPick == 2)
                    { cbHairColor.SelectedIndex = 1; }
                    else if (hairPick == 3)
                    { cbHairColor.SelectedIndex = 2; }
                    else if (hairPick == 4)
                    { cbHairColor.SelectedIndex = 3; }
                    else if (hairPick == 5)
                    { cbHairColor.SelectedIndex = 4; }
                    else if (hairPick >= 6 && hairPick <= 7)
                    { cbHairColor.SelectedIndex = 5; }
                    else if (hairPick == 8)
                    { cbHairColor.SelectedIndex = 6; }
                    else if (hairPick == 9)
                    { cbHairColor.SelectedIndex = 7; }
                    else if (hairPick == 10)
                    { cbHairColor.SelectedIndex = 8; }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public void heightRoll()
        {
            var r = new Random();
            int heightRoll = r.Next(1, 10);
            int heightBase = 52;

            switch (cbGender.SelectedIndex)
            {
                case 0:
                    switch (cbRace.SelectedIndex)
                    {
                        case 0:
                            heightBase = 50;
                            break;
                        case 1:
                            heightBase = 64;
                            break;
                        case 2:
                            heightBase = 38;
                            break;
                        case 3:
                            heightBase = 61;
                            break;
                    }
                    break;
                case 1:
                    switch (cbRace.SelectedIndex)
                    {
                        case 0:
                            heightBase = 52;
                            break;
                        case 1:
                            heightBase = 66;
                            break;
                        case 2:
                            heightBase = 40;
                            break;
                        case 3:
                            heightBase = 64;
                            break;
                    }
                    break;
            }

            int heightFeet = (heightBase + heightRoll) / 12;
            txHeight.Text = Convert.ToString(heightFeet) + "\'" + Convert.ToString((heightBase + heightRoll) - (heightFeet * 12)) + "\"";

        }

        public void markRoll()
        {
            var r = new Random();
            int markRoll = r.Next(1, 100);
            string markText = "";

            if (cbRace.SelectedIndex != 1)
            {
                if (markRoll >= 1 && markRoll <= 5)
                {
                    if (marked == 0)
                    { markText = "Pox Marks"; }
                    else
                    { markText = ", Pox Marks"; }
                }
                else if (markRoll >= 6 && markRoll <= 10)
                {
                    if (marked == 0)
                    { markText = "Ruddy Faced"; }
                    else
                    { markText = ", Ruddy Faced"; }
                }
                else if (markRoll >= 11 && markRoll <= 15)
                {
                    if (marked == 0)
                    { markText = "Scar"; }
                    else
                    { markText = ", Scar"; }
                }
                else if (markRoll >= 16 && markRoll <= 20)
                {
                    if (marked == 0)
                    { markText = "Tattoo"; }
                    else
                    { markText = ", Tattoo"; }
                }
                else if (markRoll >= 21 && markRoll <= 25)
                {
                    if (marked == 0)
                    { markText = "Earring"; }
                    else
                    { markText = ", Earring"; }
                }
                else if (markRoll >= 26 && markRoll <= 29)
                {
                    if (marked == 0)
                    { markText = "Ragged Ear"; }
                    else
                    { markText = ", Ragged Ear"; }
                }
                else if (markRoll >= 30 && markRoll <= 35)
                {
                    if (marked == 0)
                    { markText = "Nose Ring"; }
                    else
                    { markText = ", Nose Ring"; }
                }
                else if (markRoll >= 36 && markRoll <= 39)
                {
                    if (marked == 0)
                    { markText = "Wart"; }
                    else
                    { markText = ", Wart"; }
                }
                else if (markRoll >= 40 && markRoll <= 45)
                {
                    if (marked == 0)
                    { markText = "Broken Nose"; }
                    else
                    { markText = ", Broken Nose"; }
                }
                else if (markRoll >= 46 && markRoll <= 50)
                {
                    if (marked == 0)
                    { markText = "Missing Tooth"; }
                    else
                    { markText = ", Missing Tooth"; }
                }
                else if (markRoll >= 51 && markRoll <= 55)
                {
                    if (marked == 0)
                    { markText = "Snaggle Teeth"; }
                    else
                    { markText = ", Snaggle Teeth"; }
                }
                else if (markRoll >= 56 && markRoll <= 60)
                {
                    if (marked == 0)
                    { markText = "Lazy Eye"; }
                    else
                    { markText = ", Lazy Eye"; }
                }
                else if (markRoll >= 61 && markRoll <= 65)
                {
                    if (marked == 0)
                    { markText = "Missing Eyebrow(s)"; }
                    else
                    { markText = ", Missing Eyebrow(s)"; }
                }
                else if (markRoll >= 66 && markRoll <= 70)
                {
                    if (marked == 0)
                    { markText = "Missing Digit"; }
                    else
                    { markText = ", Missing Digit"; }
                }
                else if (markRoll >= 71 && markRoll <= 75)
                {
                    if (marked == 0)
                    { markText = "Missing Nail"; }
                    else
                    { markText = ", Missing Nail"; }
                }
                else if (markRoll >= 76 && markRoll <= 80)
                {
                    if (marked == 0)
                    { markText = "Distinctive Gait"; }
                    else
                    { markText = ", Distinctive Gait"; }
                }
                else if (markRoll >= 81 && markRoll <= 84)
                {
                    if (marked == 0)
                    { markText = "Curious Smell"; }
                    else
                    { markText = ", Curious Smell"; }
                }
                else if (markRoll >= 85 && markRoll <= 89)
                {
                    if (marked == 0)
                    { markText = "Huge Nose"; }
                    else
                    { markText = ", Huge Nose"; }
                }
                else if (markRoll >= 90 && markRoll <= 94)
                {
                    if (marked == 0)
                    { markText = "Large Mole"; }
                    else
                    { markText = ", Large Mole"; }
                }
                else if (markRoll >= 95 && markRoll <= 98)
                {
                    if (marked == 0)
                    { markText = "Small Bald Patch"; }
                    else
                    { markText = ", Small Bald Patch"; }
                }
                else if (markRoll >= 99 && markRoll <= 100)
                {
                    if (marked == 0)
                    { markText = "Strange Coloured Eye(s)"; }
                    else
                    { markText = ", Strange Coloured Eye(s)"; }
                }
            }

            marked = 1;
            txMarks.Text += markText;
        }

        public void siblingsRoll()
        {
            var r = new Random();
            int siblingRoll = r.Next(1,10);
            int siblingsnumber = 0;

            switch (siblingRoll)
            {
                case 1:
                    if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 1; }
                    break;
                case 2:
                case 3:
                    if(cbRace.SelectedIndex == 1 || cbRace.SelectedIndex == 3)
                    {siblingsnumber = 1;}
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 2; }
                    break;
                case 4:
                case 5:
                    if (cbRace.SelectedIndex == 0 || cbRace.SelectedIndex == 1)
                    { siblingsnumber = 1; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 3; }
                    else if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 2; }
                    break;
                case 6:
                case 7:
                    if (cbRace.SelectedIndex == 0)
                    { siblingsnumber = 1; }
                    else if (cbRace.SelectedIndex == 1)
                    { siblingsnumber = 2; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 4; }
                    else if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 3; }
                    break;
                case 8:
                case 9:
                    if (cbRace.SelectedIndex == 0 || cbRace.SelectedIndex == 1)
                    { siblingsnumber = 2; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 5; }
                    else if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 4; }
                    break;
                case 10:
                    if (cbRace.SelectedIndex == 0||cbRace.SelectedIndex==1)
                    { siblingsnumber = 3; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 6; }
                    if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 5; }
                    break;
            }
            txSiblings.Text = siblingsnumber.ToString();
        }

        public void ageRoll()
        {
            var r = new Random();
            int agePicker = r.Next(1, 100);

            if (agePicker>=1&&agePicker<=5)
            {
                if (cbRace.SelectedIndex == 0 || cbRace.SelectedIndex == 2)
                { txAge.Text = "20"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "30"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "16"; }
            }
            else if (agePicker >= 6 && agePicker <= 10)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "25"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "35"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "22"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "17"; }
            }
            else if (agePicker >= 11 && agePicker <= 15)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "30"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "40"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "24"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "18"; }
            }
            else if (agePicker >= 16 && agePicker <= 20)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "35"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "45"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "26"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "19"; }
            }
            else if (agePicker >= 21 && agePicker <= 25)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "40"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "50"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "28"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "20"; }
            }
            else if (agePicker >= 26 && agePicker <= 30)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "45"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "55"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "30"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "21"; }
            }
            else if (agePicker >= 31 && agePicker <= 35)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "50"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "60"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "32"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "22"; }
            }
            else if (agePicker >= 36 && agePicker <= 40)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "55"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "65"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "34"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "23"; }
            }
            else if (agePicker >= 41 && agePicker <= 45)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "60"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "70"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "36"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "24"; }
            }
            else if (agePicker >= 46 && agePicker <= 50)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "65"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "75"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "38"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "25"; }
            }
            else if (agePicker >= 51 && agePicker <= 55)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "70"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "80"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "40"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "26"; }
            }
            else if (agePicker >= 56 && agePicker <= 60)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "75"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "85"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "42"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "27"; }
            }
            else if (agePicker >= 61 && agePicker <=65)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "80"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "90"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "44"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "28"; }
            }
            else if (agePicker >= 66 && agePicker <= 70)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "85"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "95"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "46"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "29"; }
            }
            else if (agePicker >= 71 && agePicker <= 75)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "90"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "100"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "50"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "30"; }
            }
            else if (agePicker >= 76 && agePicker <= 80)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "95"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "105"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "52"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "31"; }
            }
            else if (agePicker >= 81 && agePicker <= 85)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "100"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "110"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "54"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "32"; }
            }
            else if (agePicker >= 86 && agePicker <= 90)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "105"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "115"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "56"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "33"; }
            }
            else if (agePicker >= 91 && agePicker <= 95)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "110"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "120"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "58"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "34"; }
            }
            else if (agePicker >= 96 && agePicker <= 100)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "115"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "125"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "60"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "35"; }
            }
        }

        private void btRerollChar_Click(object sender, EventArgs e)
        {
            txMarks.Text = "";
            marked = 0;
            characterGen();
        }

        private void btRerollStats_Click(object sender, EventArgs e)
        {
            statsRoll();
        }

        private void btAddMark_Click(object sender, EventArgs e)
        {
            markRoll();
        }

        private void btRerollMark_Click(object sender, EventArgs e)
        {
            txMarks.Text = "";
            marked = 0;
            markRoll();
        }

        private void cbRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            txMarks.Text = "";
            marked = 0;
            characterGen();
        }
    }
}