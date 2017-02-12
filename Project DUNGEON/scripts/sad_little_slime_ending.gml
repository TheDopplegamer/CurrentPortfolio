{
//Checks if the only thing in the run list is a single sad little slime
var slime_found = false;

if(ds_list_size(run_list) == 1){
    if(ds_list_find_value(run_list,0) == "Sad Slime"){
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
