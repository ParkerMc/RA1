<?php
include 'settings.php';
include 'users.php';

if(isset($_GET["cmd"])){
  $json = json_decode ($_GET["cmd"], true); //decode json from get varable cmd
  if($json["id"] == 1){
    createUser($json);
  }
}else{
  echo "Error: no varable.";
}

 ?>
