{
if(chests_opened == 0 and (ds_list_find_value(path_list,(ds_list_size(path_list)-1)) == "treasury")){
    if(ds_list_find_value(win_list,(ds_list_size(win_list)-1)) == "Throne of Avarice"){
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
