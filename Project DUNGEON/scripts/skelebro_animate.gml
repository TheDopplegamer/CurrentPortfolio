{
ani_timer += 1;
if(ani_timer == 30){
    image_index = 2;
}
else if(ani_timer == 38){
    image_index = 3;
}
else if(ani_timer == 46){
    image_index = 4;
}
else if(ani_timer == 54){
    image_index = 3;
}
else if(ani_timer == 62){
    image_index = 0;
    ani_timer = 0;
}

}
