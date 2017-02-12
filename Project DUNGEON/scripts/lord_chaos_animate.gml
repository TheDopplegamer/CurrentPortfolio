{
if(ani_timer = 0){
    new_form = irandom_range(2,37);
    ani_timer = 1;
    image_index = 0;
}

else if(ani_timer > 0){
    ani_timer += 1;
    if(ani_timer == 2){
        image_index = 1;
    }
    else if(ani_timer == 5){
        image_index = new_form;
    }
    else if(ani_timer == 10){
        image_index = 1;
    }
    else if(ani_timer == 12){
        image_index = 0;
        ani_timer = 0;
    }
}


}
