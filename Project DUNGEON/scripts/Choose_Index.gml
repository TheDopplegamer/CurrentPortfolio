{
//Determine the unit's attack and hurt index based on name

var nm = player_2.sprite_index;

if(nm == sad_slime_spr){player_2.hurt_index = 12;
    player_2.idle_animate = sad_slime_animate;
    player_2.attack_animate = sad_slime_atk_animate;
}
else if(nm == mad_slime_spr){player_2.hurt_index = 2;
    player_2.idle_animate = mad_slime_animate;
    player_2.attack_animate = mad_slime_atk_animate;
}
else if(nm == glad_slime_spr){player_2.hurt_index = 4;
    player_2.idle_animate = glad_slime_animate;
    player_2.attack_animate = glad_slime_atk_animate;
}
else if(nm == rad_slime_spr){player_2.hurt_index = 1;
    player_2.idle_animate = rad_slime_animate;
    player_2.attack_animate = rad_slime_atk_animate;
}
else if(nm == bad_slime_spr){player_2.hurt_index = 6;
    player_2.idle_animate = bad_slime_animate;
    player_2.attack_animate = bad_slime_atk_animate;
}





else if(nm == silas_the_friendly_snake_spr){player_2.hurt_index = 8;
    player_2.idle_animate = silas_animate;
    player_2.attack_animate = silas_atk_animate;
}
else if(nm == rabbid_spr){player_2.hurt_index = 4;
    player_2.idle_animate = rabbid_animate;
    player_2.attack_animate = rabbid_atk_animate;
}
else if(nm == shineko_spr){player_2.hurt_index = 4;
    player_2.idle_animate = shineko_animate;
    player_2.attack_animate = shineko_atk_animate;
}




else if(nm == skelebro_spr){player_2.hurt_index = 5;
    player_2.idle_animate = skelebro_animate;
    player_2.attack_animate = skelebro_atk_animate;
}
else if(nm == skeletal_knight_spr){player_2.hurt_index = 2;
    player_2.idle_animate = skeletal_knight_animate;
    player_2.attack_animate = skeletal_knight_atk_animate;
}
else if(nm == skeletal_mage_spr){player_2.hurt_index = 4;
    player_2.idle_animate = skeletal_mage_animate;
    player_2.attack_animate = skeletal_mage_atk_animate;
}



else if(nm == vampire_spr){player_2.hurt_index = 4;
    player_2.idle_animate = vampire_animate;
    player_2.attack_animate = vampire_atk_animate;
}
else if(nm == doppleganger_spr or nm == dopple_mage_spr or nm == dopple_rogue_spr){player_2.hurt_index = 0;
    player_2.idle_animate = doppleganger_animate;
    player_2.attack_animate = doppleganger_atk_animate;
}
else if(nm == witch_spr){player_2.hurt_index = 0;
    player_2.idle_animate = witch_animate;
    player_2.attack_animate = witch_atk_animate;
}




else if(nm == rotting_corpse_spr){player_2.hurt_index = 8;
    player_2.idle_animate = rotting_corpse_animate;
    player_2.attack_animate = rotting_corpse_atk_animate;
}
else if(nm == necromancer_spr){player_2.hurt_index = 6;
    player_2.idle_animate = necromancer_animate;
    player_2.attack_animate = necromancer_atk_animate;
}
else if(nm == parasite_spr){player_2.hurt_index = 0;
    player_2.idle_animate = parasite_animate;
    player_2.attack_animate = parasite_atk_animate;
}


else if(nm == diamand_spr){player_2.hurt_index = 5;
    player_2.idle_animate = diamand_animate;
    player_2.attack_animate = diamand_atk_animate;
}
else if(nm == emmarald_spr){player_2.hurt_index = 4;
    player_2.idle_animate = emmarald_animate;
    player_2.attack_animate = emmarald_atk_animate;
}
else if(nm == golem_spr){player_2.hurt_index = 2;
    player_2.idle_animate = golem_animate;
    player_2.attack_animate = golem_atk_animate;
}
else if(nm == the_drowned_spr){player_2.hurt_index = 0;
    player_2.idle_animate = drowned_animate;
    player_2.attack_animate = drowned_atk_animate;
}
else if(nm == salarymander_spr){player_2.hurt_index = 0;
    player_2.idle_animate = salamander_animate;
    player_2.attack_animate = salamander_atk_animate;
}
else if(nm == avatar_spr){player_2.hurt_index = 0;
    player_2.idle_animate = avatar_animate;
    player_2.attack_animate = avatar_atk_animate;
}



else if(nm == bob_mystery_spr){player_2.hurt_index = 0;
    player_2.idle_animate = bob_animate;
    player_2.attack_animate = bob_atk_animate;
}
else if(nm == hamilton_spr){player_2.hurt_index = 0;
    player_2.idle_animate = hamilton_animate;
    player_2.attack_animate = hamilton_atk_animate;
}
else if(nm == static_field_spr){player_2.hurt_index = 0;
    player_2.idle_animate = static_field_animate;
    player_2.attack_animate = static_field_atk_animate;
}
else if(nm == endless_despair_spr){player_2.hurt_index = 0;
    player_2.idle_animate = endless_despair_animate;
    player_2.attack_animate = endless_despair_atk_animate;
}
else if(nm == morticus_spr){player_2.hurt_index = 0;
    player_2.idle_animate = morticus_animate;
    player_2.attack_animate = morticus_atk_animate;
}



else if(nm == headless_angel_spr){player_2.hurt_index = 11;
    player_2.idle_animate = angel_animate;
    player_2.attack_animate = angel_atk_animate;
}
else if(nm == holy_knight_spr){player_2.hurt_index = 0;
    player_2.idle_animate = holy_knight_animate;
    player_2.attack_animate = holy_knight_atk_animate;
}
else if(nm == shining_idol_spr){player_2.hurt_index = 0;
    player_2.idle_animate = idol_animate;
    player_2.attack_animate = idol_atk_animate;
}



else if(nm == dark_lord_spr){player_2.hurt_index = 0;
    player_2.idle_animate = dark_lord_animate;
    player_2.attack_animate = dark_lord_atk_animate;
}
else if(nm == dark_lord_magic_spr){player_2.hurt_index = 0;
    player_2.idle_animate = dark_lord_animate;
    player_2.attack_animate = dark_lord_atk_animate;
}
else if(nm == dark_merchant_spr){player_2.hurt_index = 1;
    player_2.idle_animate = dark_merchant_animate;
    player_2.attack_animate = dark_merchant_atk_animate;
}
else if(nm == lord_of_chaos_spr){player_2.hurt_index = 0;
    player_2.idle_animate = lord_chaos_animate;
    player_2.attack_animate = lord_chaos_atk_animate;
}

else if(nm == mimic_spr){player_2.hurt_index = 0;
    player_2.idle_animate = mimic_animate;
    player_2.attack_animate = earl_atk_animate;
}


player_2.attack_index = player_2.hurt_index + 1;
if(player_2.attack_index == 1){player_2.attack_index = 0;} 


}
