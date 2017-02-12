{
var flip = irandom_range(1,10);
if(flip == 10 and ani_timer == 0){
    ani_timer += 1;
    if(image_index == 0){
        image_index = 1; 
    }
    else if(image_index == 1){
        image_index = 0; 
    }
}
else if(ani_timer > 0){
    ani_timer += 1;
    if(ani_timer == 7){
        ani_timer = 0;
    }
}

}
