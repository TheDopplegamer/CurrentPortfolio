{
//Calculates the ending after a game

var fail_ending = ds_list_create();
ds_list_add(fail_ending,"Many warriors challenged the Dark Lord","Many warriors dreamed of becoming heroes","Many warriors died before reaching his throne","This was one of them");
                   
var boss_fail_ending = ds_list_create();
ds_list_add(boss_fail_ending,"You were not strong enough", "The Dark Lord is not someone to be taken lightly", "One cannot simply walk into his chamber", "Hopefully, your successor will know how to grind properly");
                        
var victory_ending = ds_list_create();
ds_list_add(victory_ending,"When the lands were cast in shadow","A hero stepped up to tame the evil","They slew the Dark Lord and saved us all","For now, our kingdom shall know peace");                     
 
var legendary_ending = ds_list_create();
ds_list_add(legendary_ending, "A warrior entered", "A hero fought", "A legend emerged");

var monster_genocide_ending = ds_list_create();
ds_list_add(monster_genocide_ending,"An empty castle","The lord has vanished","The servents are nowhere to be found","Only one word could describe this castle:", "Abandoned", "What happened to everyone? Where did they all go?", "Sure, the estate needed some restructuring", "But this isn't how to go about it", "Who's going to clean up this white powder thats gotten everywhere?", "I swear, it wasn't here yesterday", "Oh well, I'm sure they'll be back soon", "Until then, I'm gonna take a nap");

var victory_at_cost_ending = ds_list_create();
ds_list_add(victory_at_cost_ending,"The legion is destroyed", "It's commander has fallen", "Peace has returned to our land", "But at what cost?", "The hero, who saved us all, could not save themselves", "We will not forget their sacrifice","Their name shall live on for generations to come");

var sad_slime_ending = ds_list_create();
ds_list_add(sad_slime_ending,"The fighting was over and the hero had left", "They slew foe after foe till no soul remained", "Save for a single little slime", "'Why?' he asked, 'Why was I spared?'","His friends, his family, all he knew was dead","He was too weak to avenge them, too weak to move on","All he could do was cry, all alone, the Sad Little Slime.");     

var complete_coward_ending = ds_list_create();;
ds_list_add(complete_coward_ending,"Unestris, plagued by the Dark Lord's legion", "Our only hope is for a gallant hero to step forth","While we wait for such a soul, we will...","....WHAT?", "Someone already entered?", "Well, did they succeed?", "No?", "Were they slain in combat?", "No?", "Then what did they do?", "Run away?", "They ran from everything?", "Even the sad little slime,", "That even level 1 noobs can handle?", "Then why bother showing up in the first place?");

var plunder_ending = ds_list_create();;                      
ds_list_add(plunder_ending,"Explorers of the dungeon were not limited to heroes", "Some did not want the glory", "They desired something from a more basic desire", "Profiteers, plunderers, thieves", "They were motivated by greed and greed alone", "Of course, there's nothing wrong with that", "Just, leave some for the rest of us, ok?");

//var remove_head_ending = ds_list_create();;
//ds_list_add(remove_head_ending,"To kill an army, you must kill their commander", "You understand this better then anyone", "You snuck into the dungeon", "Avoiding combat at all costs", "Once you found your target, you struck", "You are not a valiant hero", "You are an assassin", "Only time will tell if this was the right move", "One of his generals may just rise to power", "The dark legion may just scatter to the wind", "Only time will tell");

var villains_vengance_ending = ds_list_create();;
ds_list_add(villains_vengance_ending,"He was born with power", "He raised an army", "He became feared by all", "He lost it all", "He now has nothing", "He remembers their face", "He will have his revenge", "Count on it, hero.");

var slime_gone = ds_list_create();
ds_list_add(slime_gone,"The Dark Lord decided to hold a feast", "In honor of his force's continued dominance", "The celebration was grand and everyone had fun", "Only, something was off", "Someone was missing", "But who?", "As far as anyone could tell, every member of the dark legion was in attendance", "But still, it felt like someone was missing", "Like a perpetually crying infant that you eventaully tune out", "Sure, it's sad and annoying at first, but you learn to deal with it", "Well, that metamorphical baby has disappeared", "But nobody can remember who exactly it was.", "Oh well, they probably weren't that important anyway");

var death_by_slime = ds_list_create();
ds_list_add(death_by_slime,"Really?", "Did you really just die to a SAD SLIME?", "That is literally the WEAKEST monster in the game!", "It shouldn't even be possible to die to one!", "Wow, I congragulate you on your tenacity and cleverness", "You went REALLY out your way to see this ending", "This isn't the kind of thing that happens on accident", "You have to start a new game, thinking,", "'Okay, my goal is to die to a Sad Slime'", "What kind of ending were you expecting, anyway?", "That you'd here a nice little story", "About how a brave slime managed to stop the big, bad, hero?", "Well, lemme tell ya: I considered it");
ds_list_add(death_by_slime,  "But then I realized: That's stupid", "Nobody's actually gonna go for this ending", "Honestly, I'm just trying to fill a quota", "I'm actually typing this a couple of weeks before release" ,"at 1:00 am listening to anime music", "You wanna know something?", "Making a game is hard", "Especially since this is my first one", "Not to mention that I'm stressed out", "Because I need it to succeed", "So that I can cover my rent for a few months", "While I work on my next Project", "It's gonna be a baller, I tell ya!", "I have this whole idea of a whole fleshed out universe", "With a history spanning multiple games");
ds_list_add(death_by_slime, "It'll all culminate with this JRPG-style epic", "That I've been working on for a couple of years", "But I'm getting ahead of myself", "What were we talking about, again?", "Oh right, you were ganked by the crying blob", "Anyway, congragulations, you earned it.");


var death_by_mimic = ds_list_create();
ds_list_add(death_by_mimic,"Greed", "Something held by all adventurers", "They greed for something", "Be it wealth or glory", "Your greed, however, was pretty straightforward", "You wanted the loot, but your health was low", "'It's fine, I'll just open this chest,", "THEN I'll rest up'", "Too bad the loot wasn't as receptive to your plan", "The bloodstains will warn the next would-be profiteer. ");

//var poor_by_choice = ds_list_create();
//ds_list_add(poor_by_choice,"To defeat greed, you must refuse all wealth", "You resisted the temptations of the golden boxes,", "plentiful that they were", "And at the end of this golden tunnel", "You slew the source of such pointless affluence", "Never again will adventurers be tempted by the golden evil", "You are a beacon to future generations", "Thanks to you, nobody will ever again die to a goddamn mimic");

var ran_from_boss = ds_list_create();
ds_list_add(ran_from_boss,"Like all the others, this hero craved glory", "They set forth, slaying the monsters within","Still, for all their bravery,","They lacked the will to prevail", "Under the gaze of such a demon,", "They ran at the last moment", "This legend's hero, they were not", "A mere herald for the real champion.");

//var total_hell = ds_list_create();
//ds_list_add(total_hell,"Legends tell of a warrior who found the gates of hell", "Unwavering in their bravery, they entered", "They slew the demons within with ease", "Even the devil himself could not stop their rampage", "That warrior had conquered hades","Now, we fear them","For they have become the master of hell,", "With the power to slay even the gods themselves", "Only time will tell how they use that power", "To stamp out evil?", "Or stamp out humanity?", "Then again, what's the difference, really?");

//var death_by_bomb = ds_list_create();
//ds_list_add(death_by_bomb,"What?", "Nobody told you there'd be bombs here?", "You weren't trained for this?","Then why did they send you?", "We needed an expert!", "Luckily, the explosion was contained to a single room", "Sure, you died, but who cares?", "Your expendable, just like the rest", "I hope the next guy,at least,", "knows how to defuse a simple password locked explosive");

//var boss_revenge = ds_list_create();
//ds_list_add(boss_revenge,"He knew something was coming", "His men warned him of the danger approaching", "One by one, his soldiers fell", "Until only he remained,", "A general without an army", "At last, his rival had appeared", "No, this was no rival", "This was a monster, reveling in destruction", "If left unchecked, they would not stop here", "No, they would bring the world itself to ruin", "So he fought", "It was an intense battle, but the monster fell", "He may have lost it all,", "But at least his men did not die in vain", "The 'hero' has been stopped.");

var beat_throne = ds_list_create();
ds_list_add(beat_throne,"Where did all this gold come from?", "Plundering? Mining?", "No, this gold is a lie", "Created by the Dark Lord's evil invention", "The Throne of Avarice", "With it, the Dark Legion will have no shortage of funds", "Funds they can't spend,anyway","Cause they're monsters, duh", "Good job destroying it, though");

var chaos_beat = ds_list_create();
ds_list_add(chaos_beat,"Where am I?","What is this?","Who is that?", "He has no form","I must kill him","I killed him","How do I get out?"); 

var rh = Dungeon.result_history;
var fh = Dungeon.foe_history;

//Generate condition lists
run_list = ds_list_create();
win_list = ds_list_create();


var n = 0;
while(n < ds_list_size(rh)){
    var cur_result = ds_list_find_value(rh,n);
    var cur_name = ds_list_find_value(fh,n);
    if(cur_result == "Flee"){ds_list_add(run_list,cur_name);}
    else if(cur_result == "Win"){ds_list_add(win_list,cur_name);}
    n += 1;
}  

var rl_size = ds_list_size(run_list);
var wl_size = ds_list_size(win_list);



//Calculate the correct ending here
//Death at boss, kill everyone beforehand
//if(boss_revenge_ending()){
 //   global.end_text = boss_revenge;
  //  global.ending_background = ran_from_boss_ending_bkgd;
//}
//Death at boss
if(fail_boss_standard_ending()){
    global.end_text = boss_fail_ending;
    global.ending_background = boss_death_ending_bkgd;
}
//Death at bomb
//else if(fail_bomb_ending()){
 //   global.end_text = death_by_bomb;
//    global.ending_background = test_bkgd;
//}
//Death at mimic
else if(fail_mimic_ending()){
    global.end_text = death_by_mimic;
    global.ending_background = death_by_greed_ending_bkgd;
}
//Death by Slime
else if(fail_sad_slime_ending()){
    global.end_text = death_by_slime;
    global.ending_background = death_by_slime_ending_bkgd;
}
//Death in general
else if(fail_standard_ending()){
    global.end_text = fail_ending;
    global.ending_background = fail_ending_bkgd;    
}
//Sad slime left alone
else if(sad_little_slime_ending()){
    global.end_text = sad_slime_ending;
    global.ending_background = sad_slime_ending_bkgd;   
}
//Sad slime is killed, but everyone is is fine
else if(sad_slime_gone_ending()){
    global.end_text = slime_gone;
    global.ending_background = slime_gone_ending_bkgd;
}
//Poor by Choice Ending
//else if(poor_by_choice_ending()){
 //   global.end_text = poor_by_choice;
 //   global.ending_background = test_bkgd;
//}
//End of Avarice
else if(victory_treasury_ending()){
    global.end_text = beat_throne;
    global.ending_background = overthrown_avarice_ending_bkgd;
}
//Conquered Chaos
else if(chaos_beat_ending()){
    global.end_text = chaos_beat;
    global.ending_background = chaos_conquered_ending_bkgd;
}
//Thief ending
else if(thief_ending()){
    global.end_text = plunder_ending;
    global.ending_background = thief_ending_bkgd;   
}
//Kill only boss
//else if(boss_assassinate_ending()){
//    global.end_text = remove_head_ending;
//    global.ending_background = test_bkgd; 
//}
//Kill everyone but boss
else if(boss_alone_standard_ending()){
    global.end_text = villains_vengance_ending;
    global.ending_background = boss_alone_ending_bkgd;  
}
//Run from boss, kill a few other things
else if(ran_from_boss_ending()){
    global.end_text = ran_from_boss;
    global.ending_background = ran_from_boss_ending_bkgd;
}
//Run from everything
else if(coward_standard_ending()){
    global.end_text = complete_coward_ending;
    global.ending_background = total_coward_ending_bkgd;
}
//Kill everything
else if(genocide_ending()){
    global.end_text = monster_genocide_ending;
    global.ending_background = genocide_ending_bkgd;
}
//Standard victory with low health
else if(wounded_victory_standard_ending()){
    global.end_text = victory_at_cost_ending;
    global.ending_background = sacrifice_ending_bkgd;    
}
//Standard victory
else if(victory_standard_ending()){
    global.end_text = victory_ending;
    global.ending_background = victory_ending_bkgd;    
}
//Standard victory with full HP
else if(total_victory_standard_ending()){
    global.end_text = legendary_ending;
    global.ending_background = legendary_ending_bkgd; 
}
             

//global.end_text = fail_ending;
//global.ending_background = fail_ending_bkgd;

//Make sure the chosen ending is flagged in the database as recieved
if(global.end_text == fail_ending){ds_grid_set(global.ending_database,0,0,true);}
else if(global.end_text == boss_fail_ending){ds_grid_set(global.ending_database,0,1,true);}
else if(global.end_text == victory_ending){ds_grid_set(global.ending_database,0,2,true);}
else if(global.end_text == legendary_ending){ds_grid_set(global.ending_database,0,3,true);}

else if(global.end_text == monster_genocide_ending){ds_grid_set(global.ending_database,0,1,true);}
else if(global.end_text == victory_at_cost_ending){ds_grid_set(global.ending_database,0,2,true);}
else if(global.end_text == sad_slime_ending){ds_grid_set(global.ending_database,0,3,true);}
else if(global.end_text == complete_coward_ending){ds_grid_set(global.ending_database,0,1,true);}
else if(global.end_text == plunder_ending){ds_grid_set(global.ending_database,0,2,true);}
else if(global.end_text == villains_vengance_ending){ds_grid_set(global.ending_database,0,3,true);}
else if(global.end_text == slime_gone){ds_grid_set(global.ending_database,0,1,true);}
else if(global.end_text == death_by_slime){ds_grid_set(global.ending_database,0,2,true);}
else if(global.end_text == death_by_mimic){ds_grid_set(global.ending_database,0,3,true);}
else if(global.end_text == ran_from_boss){ds_grid_set(global.ending_database,0,1,true);}
else if(global.end_text == beat_throne){ds_grid_set(global.ending_database,0,2,true);}
else if(global.end_text == chaos_beat){ds_grid_set(global.ending_database,0,3,true);}

}
