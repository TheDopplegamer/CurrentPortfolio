{
//Checks if the only thing in the win list is a single sad little slime
var slime_found = false;

if(ds_list_size(win_list) == 1){
    if(ds_list_find_value(win_list,0) == "Sad Slime"){
        return true;
    }
    else{
        return false;
    }
}
else{
    return false;
}


}
