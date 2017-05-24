<?php
/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
require_once("php/functions.php");
session_start();

CheckConnexion();
CheckAdmin();
//Check the informations
if (isset($_POST['usersToDel'])) {
  //Go through the ids to delete and does it one by one
  foreach ($_POST['usersToDel'] as $idToDel) {
    $sql = "DELETE FROM users WHERE idUser = :id";
    $query = $db->prepare($sql);
    $query->execute(array(
      'id' => $idToDel
    ));
  }

}
header("Location: manageUsers.php");
