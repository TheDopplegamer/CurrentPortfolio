{
if(in_prayer == true){
    if(prayed == true){
        spec_alpha -= 0.05;
        if(spec_alpha < 0){
            spec_alpha = 1;
            //Hermit Statue
            //Pay Blood Toll
            player_1.HP -= 5;
            if(player_1.HP < 1){player_1.HP = 1;}
            if(prayer_type == 0){
                //Increase the number of hermits in the path
                var hr = current_y+1;
                while(hr < length-1){
                    var check_hermit = ds_grid_get(map,current_x,hr);
                    if(check_hermit != 9){
                        var new_hermit = irandom_range(1,10);
                        if(new_hermit <= 2){
                            ds_grid_set(map,current_x,hr,6);
                        }
                    }   
                    hr += 1;
                }
                Text_Box.new_text = "Hermits, come forth!";
                Update_Text();
            
            }
            //Bomb Statue
            else if(prayer_type == 1){
                //Remove all bombs from dungeon
                var br = 0;
                while(br < length-1){
                    var check_bomb = ds_grid_get(map,current_x,br);
                    if(check_bomb == 7){
                        //Replace the bomb with a chest, heal zone, shop, or slot
                        var new_space = irandom_range(1,4);
                        if(new_space == 1){ds_grid_set(map,current_x,br,3)}
                        else if(new_space == 2){ds_grid_set(map,current_x,br,4)}
                        else if(new_space == 3){ds_grid_set(map,current_x,br,6)}
                        else if(new_space == 4){ds_grid_set(map,current_x,br,8)}
                    }
                    br += 1;
                }
                Text_Box.new_text = "Bombs, disperse!";
                Update_Text();
            }
            //Slime Statue
            else{
                slime_prayed = true;
                Text_Box.new_text = "Slimes, come forth!";
                Update_Text();
            }
            //Advance to next room
            prayed = false;
            in_prayer = false;
            current_y += 1;
        }       
    }
}


}
