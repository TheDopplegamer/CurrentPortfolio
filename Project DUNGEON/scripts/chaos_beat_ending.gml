{
if(ds_list_find_value(path_list,(ds_list_size(path_list)-1)) == "chaos"){
    if(ds_list_find_value(win_list,(ds_list_size(win_list)-1)) == "Marquis de Chaos"){
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
