use sportsmanager;

DELIMITER $$
CREATE PROCEDURE UpdatePASS(IN emailMEU VARCHAR(50))
	UPDATE UTILIZADOR SET password = SHA1(password) WHERE email = emailMEU;
END$$