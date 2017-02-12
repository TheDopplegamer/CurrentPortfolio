{
//Inserts a new line into the text box

var m = Text_Box.max_lines;

while(m > 0){
    Text_Box.text[m] = Text_Box.text[m-1];
    m -= 1;    
}

Text_Box.text[0] = Text_Box.new_text;
//Add the new text to the log
ds_list_add(Text_Box.log,Text_Box.new_text);


}
