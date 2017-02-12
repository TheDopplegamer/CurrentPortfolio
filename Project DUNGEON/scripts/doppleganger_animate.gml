{



ani_timer += 1;

if(ani_timer == 6){
    image_index = 1;
}
else if(ani_timer == 12){
    image_index = 1;
}
else if(ani_timer == 18){
    image_index = 2;
}
else if(ani_timer == 24){
    image_index = 3;
}
else if(ani_timer == 30){
    image_index = 0;
    ani_timer = 0;
}
}
