<?php
include 'utils.php';

function checkLogin($json){
  include 'settings.php';
  //connect to db
  $link = mysqli_connect($db["host"], $db["username"], $db["password"], $db["database"])
  or die('{"success":false, "msg":"Error connecting to database."}');
  $query = "SELECT username, token, tokenExp FROM users where username='" . $json["username"] . "'";
  $result = mysqli_query($link, $query);
  if(mysqli_num_rows($result) > 0){
    $user =  mysqli_fetch_assoc($result);
    if($user["token"]==$json["token"] && time() < strtotime($user["tokenExp"])){
      return true;
    }
  }
    return false;
}

function login($json){
  include 'settings.php';
  //connect to db
  $link = mysqli_connect($db["host"], $db["username"], $db["password"], $db["database"])
  or die('{"success":false, "msg":"Error connecting to database."}');
  $query = "SELECT uid, username, email, password FROM users where username='" . htmlspecialchars($json["username"]) .
  "' OR email='" . htmlspecialchars($json["username"]) . "'";
  $result = mysqli_query($link, $query);
  if(mysqli_num_rows($result) > 0){
    $user =  mysqli_fetch_assoc($result);
    if(password_verify(htmlspecialchars($json["password"]), $user['password'])){
      $token = randomString(40);
      $query = "SELECT username FROM users where token='" . $token . "'";
      $result = mysqli_query($link, $query);
      while(mysqli_num_rows($result) > 0){
        $token = randomString(40);
        $query = "SELECT username FROM users where token='" . $token . "'";
        $result = mysqli_query($link, $query);
      }
      $query = "UPDATE users SET token = '" . $token . "', tokenExp = '" . date('m/d/Y h:i:s a', strtotime("+1 week")) . "',
      ip = '" . htmlspecialchars(getRealIpAddr()) . "' WHERE users.uid = ". $user["uid"];
      $result = mysqli_query($link, $query) or die('{"success":false, "msg":"Error logingin."}');
      echo '{"success":true, "msg":"User logedin.", "username":"' . $user["username"] . '", "token":"' . $token . '"}';
    }else{
      echo '{"success":false, "msg":"Incorrect password."}';
    }
  }else{
    echo '{"success":false, "msg":"Username or email dose not have an account."}';
  }
}

function createUser($json){
  include 'settings.php';
  //connect to db
  $link = mysqli_connect($db["host"], $db["username"], $db["password"], $db["database"])
  or die('{"success":false, "msg":"Error connecting to database."}');

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
      $result = mysqli_query($link, $query) or die('{"success":false, "msg":"Error createing user."}');
      login($json);
    }else{
      echo '{"success":false, "msg":"There is already an account with that E-mail."}';
    }
  }else{
    echo '{"success":false, "msg":"Username already exists."}';
  }
  mysqli_close($link);
}
 ?>
