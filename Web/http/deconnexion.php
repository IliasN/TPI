<?php
//Delete everything in the session to unlog the user
session_start();
session_unset();
header("Location: index.php");
