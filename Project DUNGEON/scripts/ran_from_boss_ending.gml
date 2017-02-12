{
//Checks if the boss was ran away from

if(ds_list_size(win_list) >= 1){
    if(ds_list_find_value(run_list,ds_list_size(run_list)-1) == "Dark Lord" or ds_list_find_value(run_list,ds_list_size(run_list)-1) == "Marquis de Chaos" or ds_list_find_value(run_list,ds_list_size(run_list)-1) == "Throne of Avarice"){
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
