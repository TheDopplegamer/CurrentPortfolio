{
//Generate a group of floors for an endless segment
//Level chart
//-------------
// level > 0 - monster with the designated level
//  0 = Nothing
// -1 = heal zone
// -2 = shop
// -3 = bomb
// -4 = slot
// -5 = prayer statue
// -6 = chest

length = 21;

//Calculate the curve and boss level based on the segment number
var boss_increase = floor(segment/3);

//Boss Level determines the max enemy level
boss_level = 50 + (10 * boss_increase);
if(boss_level > 90){boss_level = 90;}

//Curve Level determines how early high level enemies appear
curve_level = segment - (boss_increase * 3);


//Calculate the level order based on the curve and boss parameters
level_list = ds_list_create();
var emlist = 0;
while(emlist < length){
    ds_list_add(level_list,0);
    emlist += 1;
}

//Create four blocks of enemy levels
//Each block has a designated enemy level
//The curve determines when to put a higher or lower level block enemy in a certain block
var block_1 = ds_queue_create();
var block_2 = ds_queue_create();
var block_3 = ds_queue_create();
var block_4 = ds_queue_create();


var boss_diff = boss_level-50;

var total_diff = boss_level-7+irandom_range(-1,0);

var tier_gate = total_diff/4;



block_1_min = 7;
block_1_max = 7+(tier_gate+(irandom_range(-1,1)));
block_2_min = block_1_max+(irandom_range(-1,1));
block_2_max = block_2_min+(tier_gate+(irandom_range(-1,1)));
block_3_min = block_2_max+(irandom_range(-1,1));;
block_3_max = block_3_min+(tier_gate+(irandom_range(-1,1)));
block_4_min = block_3_max+(irandom_range(-1,1));;
block_4_max = boss_level+(irandom_range(-1,0));

block_1_size = 3;
block_2_size = 3;
block_3_size = 3;
block_4_size = 3;

//While each block is guarenteed to have at least 3 monsters, there is the chance that up to 1 can have an additional monster
var additional = irandom_range(0,1);
var added = 0;
while(added < additional){
    var block_to_increase = irandom_range(1,4);
    if(block_to_increase == 1){
        if(block_1_size == 3){
            block_1_size = 4;
            added += 1;
        }
    }
    else if(block_to_increase == 2){
        if(block_2_size == 3){
            block_2_size = 4;
            added += 1;
        }
    }
    else if(block_to_increase == 3){
        if(block_3_size == 3){
            block_3_size = 4;
            added += 1;
        }
    }
    else if(block_to_increase == 4){
        if(block_4_size == 3){
            block_4_size = 4;
            added += 1;
        }
    }
}

//I DARE YOU to figure this shit out, hackers

//Determine levels for curve 0
if(curve_level == 0){
    //Block 1
    
    //RULE: Either the first or second HAS to be within 4 levels of the min
    var forced_min_1 = irandom_range(1,2);
    var forced_min_2 = irandom_range(1,2);
    var forced_min_3 = irandom_range(1,2);
    var forced_min_4 = irandom_range(1,2);
    
    
    if(forced_min_1 == 1){
        var val_1 = irandom_range(block_1_min,block_1_min+4);
        var val_2 = irandom_range(block_1_min,block_1_max);
    }
    else{
        var val_1 = irandom_range(block_1_min,block_1_max);
        var val_2 = irandom_range(block_1_min,block_1_min+4);
    }
    var val_3 = irandom_range(block_1_min,block_1_max);
    var val_4 = irandom_range(block_1_min,block_1_max);
    ds_queue_enqueue(block_1,val_1,val_2,val_3);
    if(block_1_size == 4){ds_queue_enqueue(block_1,val_4)}
    
    //Block 2
    //Randomly decide which value will be the lower one
    var which_change = irandom_range(1,3);
    if(which_change == 1){
        val_1 = irandom_range(block_1_min,block_1_max);
        if(forced_min_2 == 1){
            val_2 = irandom_range(block_2_min,block_2_min+4);
            val_3 = irandom_range(block_2_min,block_2_max);
        }
        else{
            val_2 = irandom_range(block_2_min,block_2_max);
            val_3 = irandom_range(block_2_min,block_2_min+4);
        }
    }
    else if(which_change == 2){
        if(forced_min_2 == 1){
            val_1 = irandom_range(block_2_min,block_2_min+4);
            val_3 = irandom_range(block_2_min,block_2_max);
        }    
        else{
            val_1 = irandom_range(block_2_min,block_2_max);
            val_3 = irandom_range(block_2_min,block_2_min+4);
        }
        
        val_2 = irandom_range(block_1_min,block_1_max);
        
    }
    else if(which_change == 3){
        if(forced_min_2 == 1){
            val_1 = irandom_range(block_2_min,block_2_min+4);
            val_2 = irandom_range(block_2_min,block_2_max);
        }
        else{
            val_1 = irandom_range(block_2_min,block_2_max);
            val_2 = irandom_range(block_2_min,block_2_min+4);
        }    
        val_3 = irandom_range(block_1_min,block_1_max);
    }
    //The 4th value can have a level anywhere in between
    val_4 = irandom_range(block_1_min,block_2_max);
    ds_queue_enqueue(block_2,val_1,val_2,val_3);
    if(block_2_size == 4){ds_queue_enqueue(block_2,val_4)}
    
    //Block 3
    //Randomly decide which value will be the lower one
    var which_change = irandom_range(1,3);
    if(which_change == 1){
        val_1 = irandom_range(block_2_min,block_2_max);
        if(forced_min_3 == 1){
            val_2 = irandom_range(block_3_min,block_3_min+4);
            val_3 = irandom_range(block_3_min,block_3_max);
        }
        else{
            val_2 = irandom_range(block_3_min,block_3_max);
            val_3 = irandom_range(block_3_min,block_3_min+4);
        }
    }
    else if(which_change == 2){
        if(forced_min_3 == 1){
            val_1 = irandom_range(block_3_min,block_3_min+4);
            val_3 = irandom_range(block_3_min,block_3_max);
        }
        else{
            val_1 = irandom_range(block_3_min,block_3_max);
            val_3 = irandom_range(block_3_min,block_3_min+4);
        }
        val_2 = irandom_range(block_2_min,block_2_max);
    }
    else if(which_change == 3){
        if(forced_min_3 == 1){
            val_1 = irandom_range(block_3_min,block_3_min+4);
            val_2 = irandom_range(block_3_min,block_3_max);
        }    
        else{
            val_1 = irandom_range(block_3_min,block_3_max);
            val_2 = irandom_range(block_3_min,block_3_min+4);
        }
        val_3 = irandom_range(block_2_min,block_2_max);
    }
    //The 4th value can have a level anywhere in between
    val_4 = irandom_range(block_2_min,block_3_max);
    ds_queue_enqueue(block_3,val_1,val_2,val_3);
    if(block_3_size == 4){ds_queue_enqueue(block_3,val_4)}
    
    //Block 4
    //Randomly decide which value will be the lower one
    var which_change = irandom_range(1,3);
    if(which_change == 1){
        val_1 = irandom_range(block_3_min,block_3_max);
        if(forced_min_4 == 1){
            val_2 = irandom_range(block_4_min,block_4_min+4);
            val_3 = irandom_range(block_4_min,block_4_max);
        }
        else{
            val_2 = irandom_range(block_4_min,block_4_max);
            val_3 = irandom_range(block_4_min,block_4_min+4);
        }    
    }
    else if(which_change == 2){
        if(forced_min_4 == 1){
            val_1 = irandom_range(block_4_min,block_4_min+4);
            val_3 = irandom_range(block_4_min,block_4_max);
        }
        else{
            val_1 = irandom_range(block_4_min,block_4_max);
            val_3 = irandom_range(block_4_min,block_4_min+4);
        }    
        val_2 = irandom_range(block_3_min,block_3_max);
    }
    else if(which_change == 3){
        if(forced_min_4 == 1){
            val_1 = irandom_range(block_4_min,block_4_min+4);
            val_2 = irandom_range(block_4_min,block_4_max);    
        }
        else{   
            val_1 = irandom_range(block_4_min,block_4_max);
            val_2 = irandom_range(block_4_min,block_4_min+4);
        }    
        val_3 = irandom_range(block_3_min,block_3_max);
    }
    //The 4th value can have a level anywhere in between
    val_4 = irandom_range(block_3_min,block_4_max);
    ds_queue_enqueue(block_4,val_1,val_2,val_3);
    if(block_4_size == 4){ds_queue_enqueue(block_4,val_4)} 
}

//Curve 1
else if(curve_level == 1){
    //Block 1
    
    //RULE: Either the first or second HAS to be within 4 levels of the min
    var forced_min_1 = irandom_range(1,2);
    var forced_min_2 = irandom_range(1,2);
    var forced_min_3 = irandom_range(1,2);
    var forced_min_4 = irandom_range(1,2);
    
    if(forced_min_1 == 1){
        var val_1 = irandom_range(block_1_min,block_1_min+4);
        var val_2 = irandom_range(block_1_min,block_1_max);
    }
    else{
        var val_1 = irandom_range(block_1_min,block_1_max);
        var val_2 = irandom_range(block_1_min,block_1_min+4);
    }
    var val_3 = irandom_range(block_1_min,block_1_max);
    var val_4 = irandom_range(block_1_min,block_1_max);
    ds_queue_enqueue(block_1,val_1,val_2,val_3);
    if(block_1_size == 4){ds_queue_enqueue(block_1,val_4)}   
    
    //Block 2
    if(forced_min_2 == 1){
        var val_1 = irandom_range(block_2_min,block_2_min+4);
        var val_2 = irandom_range(block_2_min,block_2_max);
    }
    else{    
        var val_1 = irandom_range(block_2_min,block_2_max);
        var val_2 = irandom_range(block_2_min,block_2_min+4);
    }    
    var val_3 = irandom_range(block_2_min,block_2_max);
    var val_4 = irandom_range(block_2_min,block_2_max);
    ds_queue_enqueue(block_2,val_1,val_2,val_3);
    if(block_2_size == 4){ds_queue_enqueue(block_2,val_4)}
    
    //Block 3
    if(forced_min_3 == 1){
        var val_1 = irandom_range(block_3_min,block_3_min+4);
        var val_2 = irandom_range(block_3_min,block_3_max);
    }
    else{
        var val_1 = irandom_range(block_3_min,block_3_max);
        var val_2 = irandom_range(block_3_min,block_3_min+4);
    }
    var val_3 = irandom_range(block_3_min,block_3_max);
    var val_4 = irandom_range(block_3_min,block_3_max);
    ds_queue_enqueue(block_3,val_1,val_2,val_3);
    if(block_3_size == 4){ds_queue_enqueue(block_3,val_4)}
    
    //Block 4
    if(forced_min_4 == 1){
        var val_1 = irandom_range(block_4_min,block_4_min+4);
        var val_2 = irandom_range(block_4_min,block_4_max);
    }
    else{
        var val_1 = irandom_range(block_4_min,block_4_max);
        var val_2 = irandom_range(block_4_min,block_4_min+4);
    }
    var val_3 = irandom_range(block_4_min,block_4_max);
    var val_4 = irandom_range(block_4_min,block_4_max);
    ds_queue_enqueue(block_4,val_1,val_2,val_3);
    if(block_4_size == 4){ds_queue_enqueue(block_4,val_4)}
}

//Curve 2
else if(curve_level == 2){
    //Block 1
    
    //RULE: Either the first or second HAS to be within 4 levels of the min
    var forced_min_1 = irandom_range(1,2);
    var forced_min_2 = irandom_range(1,2);
    var forced_min_3 = irandom_range(1,2);
    var forced_min_4 = irandom_range(1,2);
    
    var which_change = irandom_range(1,3);
    if(which_change == 1){
        var val_1 = irandom_range(block_2_min,block_2_max);
        if(forced_min_1 == 1){
            var val_2 = irandom_range(block_1_min,block_1_min+4);
            var val_3 = irandom_range(block_1_min,block_1_max);
        }
        else{    
            var val_2 = irandom_range(block_1_min,block_1_max);
            var val_3 = irandom_range(block_1_min,block_1_min+4);
        }    
    }
    else if(which_change == 2){
        if(forced_min_1 == 1){
            var val_1 = irandom_range(block_1_min,block_1_min+4);
            var val_3 = irandom_range(block_1_min,block_1_max);
        }
        else{
            var val_1 = irandom_range(block_1_min,block_1_max);
            var val_3 = irandom_range(block_1_min,block_1_min+4);
        }    
        var val_2 = irandom_range(block_2_min,block_2_max);
        
    }
    else if(which_change == 3){
        if(forced_min_1 == 1){
            var val_1 = irandom_range(block_1_min,block_1_min+4);
            var val_2 = irandom_range(block_1_min,block_1_max);
        }
        else{
            var val_1 = irandom_range(block_1_min,block_1_max);
            var val_2 = irandom_range(block_1_min,block_1_min+4);
        }
        
        var val_3 = irandom_range(block_2_min,block_2_max);
    }
    var val_4 = irandom_range(block_1_min,block_2_max);
    ds_queue_enqueue(block_1,val_1,val_2,val_3);
    if(block_1_size == 4){ds_queue_enqueue(block_1,val_4)}
    
    //Block 2
    //Randomly decide which value will be the higher one
    var which_change = irandom_range(1,3);
    if(which_change == 1){
        val_1 = irandom_range(block_3_min,block_3_max);
        if(forced_min_2 == 1){
            val_2 = irandom_range(block_2_min,block_2_min+4);
            val_3 = irandom_range(block_2_min,block_2_max);
        }
        else{    
            val_2 = irandom_range(block_2_min,block_2_max);
            val_3 = irandom_range(block_2_min,block_2_min+4);
        }    
    }
    else if(which_change == 2){
        if(forced_min_2 == 1){
            val_1 = irandom_range(block_2_min,block_2_min+4);
            val_3 = irandom_range(block_2_min,block_2_max);
        }
        else{
            val_1 = irandom_range(block_2_min,block_2_max);
            val_3 = irandom_range(block_2_min,block_2_min+4);
        }    
        val_2 = irandom_range(block_3_min,block_3_max);
    }
    else if(which_change == 3){
        if(forced_min_2 == 1){
            val_1 = irandom_range(block_2_min,block_2_min+4);
            val_2 = irandom_range(block_2_min,block_2_max);
        }
        else{
            val_1 = irandom_range(block_2_min,block_2_max);
            val_2 = irandom_range(block_2_min,block_2_min+4);
        }
        val_3 = irandom_range(block_3_min,block_3_max);
    }
    //The 4th value can have a level anywhere in between
    val_4 = irandom_range(block_2_min,block_3_max);
    ds_queue_enqueue(block_2,val_1,val_2,val_3);
    if(block_2_size == 4){ds_queue_enqueue(block_2,val_4)}
    
    //Block 3
    //Randomly decide which value will be the higher one
    var which_change = irandom_range(1,3);
    if(which_change == 1){
        val_1 = irandom_range(block_4_min,block_4_max);
        if(forced_min_3 == 1){
            val_2 = irandom_range(block_3_min,block_3_min+4);
            val_3 = irandom_range(block_3_min,block_3_max);
        }
        else{    
            val_2 = irandom_range(block_3_min,block_3_max);
            val_3 = irandom_range(block_3_min,block_3_min+4);
        }    
    }
    else if(which_change == 2){
        if(forced_min_3 == 1){
            val_1 = irandom_range(block_3_min,block_3_min+4);
            val_3 = irandom_range(block_3_min,block_3_max);
        }
        else{    
            val_1 = irandom_range(block_3_min,block_3_max);
            val_3 = irandom_range(block_3_min,block_3_min+4);
        }
        val_2 = irandom_range(block_4_min,block_4_max);
    }
    else if(which_change == 3){
        if(forced_min_3 == 1){
            val_1 = irandom_range(block_3_min,block_3_min+4);
            val_2 = irandom_range(block_3_min,block_3_max);
        }
        else{    
            val_1 = irandom_range(block_3_min,block_3_max);
            val_2 = irandom_range(block_3_min,block_3_min+4);
        }    
        val_3 = irandom_range(block_4_min,block_4_max);
    }
    //The 4th value can have a level anywhere in between
    val_4 = irandom_range(block_3_min,block_4_max);
    ds_queue_enqueue(block_3,val_1,val_2,val_3);
    if(block_3_size == 4){ds_queue_enqueue(block_3,val_4)}
    
    //Block 4
    if(forced_min_4 == 1){
        val_1 = irandom_range(block_4_min,block_4_min+4);
        val_2 = irandom_range(block_4_min,block_4_max);
    }
    else{
        val_1 = irandom_range(block_4_min,block_4_max);
        val_2 = irandom_range(block_4_min,block_4_min+4);
    }
    val_3 = irandom_range(block_4_min,block_4_max);
    val_4 = irandom_range(block_4_min,block_4_max);
    ds_queue_enqueue(block_4,val_1,val_2,val_3);
    if(block_4_size == 4){ds_queue_enqueue(block_4,val_4)} 
}
//var chest_count = 0;
//var heal_count = 0;
//var shop_count = 0;
//var bomb_count = 0;
//var slot_count = 0;
//var pray_count = 0;

//Make copies of the queues in case we need a do over

//Once the order of enemy levels has been decided, insert them into the list in order, randomly inserting special levels for events

//Calculate the total number of special floors
var monster_total = block_1_size+block_2_size+block_3_size+block_4_size;
var special_total = (length-2) - monster_total;


/////////////////////////////////////////////////////////////////////////////
//Calculate the total XP needed for a guarenteed chance of beating the boss

target_level = boss_level+5;

//The percent of monsters needed to beat to progress

var percent = 0.65 + (0.5 * segment);

if(percent > 0.85){
    percent = 0.85;
}


var monster_goal = round(monster_total*percent);
//Allow a 1 monster error modifier in either direction
var error = irandom_range(-1,1);

monster_goal += error;

//Assuming a starting level of 13, calculate the XP necassary to hit the target level based on the monster goal
var levels_needed = target_level-13;

//Assume that it takes, on average, 3 xp to level up once, THIS MAY CHANGE LATER
var total_xp = levels_needed * 3;

segment_xp = round(total_xp/monster_goal);



////////////////////////////////////////////////////////////////////////////



//Don't let there be more then two slot machine's
//Except for a 33% chance to break that rule, in
//which case, don't let there be more then three

var num_of_slots = 0;

var rule_broken = irandom_range(-1,1);


//Pick random floors to insert special events
var s = 0;
while(s < special_total){
    var new_spec = irandom_range(1,length-2);
    //Make sure there is nothing there already
    var check_floor = ds_list_find_value(level_list,new_spec);
    if(check_floor == 0){
        //Choose a random special event, then insert it into the list
        var spec_type = irandom_range(1,5);
        
        //Make sure the slot rule is being followed
        if(spec_type == 4){
            if((num_of_slots == 2 and rule_broken != 1) or (num_of_slots == 3 and rule_broken == 1)){
                while(spec_type == 4){
                    spec_type = irandom_range(1,5);        
                }
            }
        }
        
        if(spec_type == 5){spec_type = 6;}
        spec_type = -1 * spec_type;
        ds_list_replace(level_list,new_spec,spec_type);
        s += 1;
    }
}

//Insert the levels from the queue into the list
var f = 1;
while(f < length-1){
    var check_floor = ds_list_find_value(level_list,f);
    if(check_floor == 0){
        if(!ds_queue_empty(block_1)){
            var new_level = ds_queue_head(block_1);
            ds_queue_dequeue(block_1);
        }
        else if(!ds_queue_empty(block_2)){
            var new_level = ds_queue_head(block_2);
            ds_queue_dequeue(block_2);
        }
        else if(!ds_queue_empty(block_3)){
            var new_level = ds_queue_head(block_3);
            ds_queue_dequeue(block_3);
        }
        else if(!ds_queue_empty(block_4)){
            var new_level = ds_queue_head(block_4);
            ds_queue_dequeue(block_4);
        }
        else{var new_level = 0;}
        ds_list_replace(level_list,f,new_level);
    }
    f += 1;    
}


//Let there be a 40% chance to replace one of the first 10 monsters with a prayer statue
var find_prayer = irandom_range(1,10);
if(find_prayer <= 4){
    var found_empty = false;
    while(found_empty == false){
        var rroom = irandom_range(1,10);
        var croom = ds_list_find_value(level_list,rroom);
        if(croom > 0){
            ds_list_replace(level_list,rroom,-5);
            found_empty = true;
        }
    } 
}

//Convert one monster room into a chest
var lmon = ds_list_size(level_list);
var chested = false;

while(!chested){
    var rchest = irandom_range(0,lmon-1);
    var cchest = ds_list_find_value(level_list,rchest);
    if(cchest > 0){
        ds_list_replace(level_list,rchest,-6);
        chested = true;
    }
}



//Add the boss level to the tail end of the list
ds_list_replace(level_list,20,boss_level);

//Clear up the queue memory
ds_queue_destroy(block_1);
ds_queue_destroy(block_2);
ds_queue_destroy(block_3);
ds_queue_destroy(block_4);



}
