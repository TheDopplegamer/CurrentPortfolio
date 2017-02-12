{



ani_timer += 1;
if(ani_timer >= 5){
    image_index += 1;
    if(image_index == 11){
        image_index = 0;
    }
    ani_timer = 0;
}


move_timer += 1;
if(move_timer == 3){
    cur_y -= 1;
}
else if(move_timer == 6){
    cur_y -= 1;
}
else if(move_timer == 9){
    cur_y -= 1;
}
else if(move_timer == 15){
    cur_y += 1;
}
else if(move_timer == 18){
    cur_y += 1;
}
else if(move_timer == 21){
    cur_y += 1;
}
else if(move_timer == 24){
    cur_y += 1;
}
else if(move_timer == 27){
    cur_y += 1;
}
else if(move_timer == 30){
    cur_y += 1;
}
else if(move_timer == 36){
    cur_y -= 1;
}
else if(move_timer == 39){
    cur_y -= 1;
}
else if(move_timer == 42){
    cur_y -= 1;
}
else if(move_timer == 45){
    move_timer = 0;
}




}
