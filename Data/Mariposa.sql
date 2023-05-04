DROP DATABASE IF EXISTS `Mariposa`;
CREATE DATABASE IF NOT EXISTS `Mariposa` DEFAULT CHARACTER SET latin1;
USE `Mariposa`;

-- -----------------------------------------------------
-- Table `Mariposa`.`butterflies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Mariposa`.`butterflies` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `LatinName` VARCHAR(50) NULL DEFAULT NULL,
  `PolishName` VARCHAR(50) NULL DEFAULT NULL,
  `Description` MEDIUMTEXT NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
  ) 
DEFAULT CHARACTER SET = utf8mb4;

INSERT INTO `Mariposa`.`butterflies` (`LatinName`, `PolishName`, `Description`)
VALUES ("Acherontia Atropos", "Zmierzchnica Trupia Główka", "Ćma z rodziny zawisakowatych, jeden z trzech gatunków rodzaju Acherontia. Na tułowiu ma charakterystyczny wzór przypominający czaszkę, któremu zawdzięcza swoją nazwę."), 
("Actias Luna", "Księżycówka Amerykańska", "Nocny motyl należący do rodziny Saturniidae. Charakteryzuje się jasnozielonym ubarwieniem oraz obecnością przyoczek na przednich i tylnych skrzydłach. Gatunek ten występuje na terenach zalesionych i wydaje się preferować lasy dobrze zdrenowane. Dorosłych przyciąga światło.");


Select * from `Mariposa`.`butterflies`;
SELECT AUTO_INCREMENT FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = "Mariposa" AND TABLE_NAME = "butterflies";

CREATE TABLE IF NOT EXISTS `Mariposa`.`users` (
  `UserId` INT NOT NULL AUTO_INCREMENT,
  `UserName` VARCHAR(50) NOT NULL UNIQUE,
  `UserPassword` VARCHAR(50) NOT NULL,
  `PhotoURL` VARCHAR(3000) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
  ) 
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Mariposa`.`posts`  (
    `PostId` INT NOT NULL AUTO_INCREMENT,
    `UserId` INT NOT NULL,
    `Content` VARCHAR(5000) NOT NULL,
    PRIMARY KEY (`PostId`),
    FOREIGN KEY (`UserId`) REFERENCES `Mariposa`.`users`(`UserId`)
)
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Mariposa`.`postImages`  (
    `PostImageId` INT NOT NULL AUTO_INCREMENT,
    `PostId` INT NOT NULL,
    `ImageURL` VARCHAR(5000) NOT NULL,
    PRIMARY KEY (`PostImageId`),
    FOREIGN KEY (`PostId`) REFERENCES `Mariposa`.`posts`(`PostId`)
)
DEFAULT CHARACTER SET = utf8mb4;

