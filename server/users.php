<?php
include 'utils.php';

function createUser($json){
  include 'settings.php';
  //connect to db
  $link = mysqli_connect($db["host"], $db["username"], $db["password"], $db["database"])
  or die('{"id":0, "msg":"Error connecting to database."}');

  //check if user exists
  $query = "SELECT username from users where username='" . htmlspecialchars($json["username"]) . "'";
  $result = mysqli_query($link, $query);
  if(mysqli_num_rows($result) < 1){
    $query = "SELECT email from users where email='" . htmlspecialchars($json["email"]) . "'";
    $result = mysqli_query($link, $query);
    if(mysqli_num_rows($result) < 1){
      $query = "INSERT INTO `users` (`uid`, `username`, `email`, `password`, `ip`)
      VALUES (NULL, '" . htmlspecialchars($json["username"]) . "', '" . htmlspecialchars($json["email"]) . "',
      '" . password_hash(htmlspecialchars($json["password"]), PASSWORD_DEFAULT) . "', '" . htmlspecialchars(getRealIpAddr()) . "')";
      $result = mysqli_query($link, $query) or die('{"id":0, "msg":"Error createing user."}');
      echo '{"id":1, "msg":"User created."}';
    }else{
      echo '{"id":0, "msg":"There is already an account with that E-mail."}';
    }
  }else{
    echo '{"id":0, "msg":"Username already exists."}';
  }
  mysqli_close($link);
}
 ?>
