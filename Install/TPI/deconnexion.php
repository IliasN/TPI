<?php
/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
//Delete everything in the session to unlog the user
session_start();
session_unset();
header("Location: index.php");
