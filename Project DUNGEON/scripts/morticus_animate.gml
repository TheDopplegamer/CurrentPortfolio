{
if(ani_timer == 0){
    blink_timer = 0;
    blink = false;
}

if(blink == false){
    ani_timer += 1;
    if(ani_timer == 4){
        if(image_index == 3){image_index = 0;}
        else{image_index += 1;}
        ani_timer = 1
    }    
    blink_timer += 1;
    if(blink_timer >= irandom_range(15,30)){
        blink_timer = 0;
        blink = true;
        image_index = 4;
        ani_timer = 1;
    }
}
else{
    ani_timer += 1;
    if(ani_timer == 3){
        ani_timer = 1;
        if(image_index == 8){
            image_index = 0;
            blink = false;
            blink_timer = 0;
            ani_timer = 0;
        }
        else{
            image_index += 1;
        }
    }
}


}
