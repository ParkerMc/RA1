<?php
include 'settings.php';
include 'users.php';
//checkLogin($json);
if(isset($_POST["cmd"])){
  $json = json_decode ($_POST["cmd"], true); //decode json from get varable cmd
  if($json["id"] == 1){
    createUser($json);
  }elseif($json["id"] == 2){
    login($json);
  }

}else{
  echo "Error: no varable.";
}

 ?>
