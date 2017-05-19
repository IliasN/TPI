<?php
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
