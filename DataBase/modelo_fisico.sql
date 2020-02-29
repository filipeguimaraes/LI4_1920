-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema SportsManager
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema SportsManager
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SportsManager` DEFAULT CHARACTER SET utf8 ;
USE `SportsManager` ;

-- -----------------------------------------------------
-- Table `SportsManager`.`UTILIZADOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`UTILIZADOR` (
  `nif` VARCHAR(9) NOT NULL,
  `nome` VARCHAR(128) NOT NULL,
  `genero` VARCHAR(1) NULL,
  `telemovel` VARCHAR(20) NULL,
  `email` VARCHAR(128) NULL,
  `DOB` DATE NULL,
  `altura` INT NULL,
  `password` VARCHAR(16) NOT NULL,
  `morada` VARCHAR(256) NULL,
  PRIMARY KEY (`nif`),
  UNIQUE INDEX `DOB_UNIQUE` (`DOB` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportsManager`.`ESPACOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`ESPACOS` (
  `cod_espaco` INT NOT NULL,
  `tipo` VARCHAR(45) NULL,
  `lotacao` INT NOT NULL,
  `local` VARCHAR(256) NOT NULL,
  `preco` FLOAT NOT NULL,
  `area` INT NULL,
  `disponivel_ini` DATETIME NULL,
  `disponivel_fim` DATETIME NULL,
  PRIMARY KEY (`cod_espaco`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportsManager`.`MODALIDADE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`MODALIDADE` (
  `designacao` VARCHAR(36) NOT NULL,
  PRIMARY KEY (`designacao`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportsManager`.`INSTRUTOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`INSTRUTOR` (
  `nif` VARCHAR(9) NOT NULL,
  `nome` VARCHAR(128) NOT NULL,
  `password` VARCHAR(16) NOT NULL,
  `email` VARCHAR(128) NULL,
  `telefone` VARCHAR(20) NULL,
  `modalidade` VARCHAR(36) NOT NULL,
  PRIMARY KEY (`nif`),
  INDEX `fk_INSTRUTOR_MODALIDADE_idx` (`modalidade` ASC) VISIBLE,
  CONSTRAINT `fk_INSTRUTOR_MODALIDADE`
    FOREIGN KEY (`modalidade`)
    REFERENCES `SportsManager`.`MODALIDADE` (`designacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportsManager`.`AULA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`AULA` (
  `cod_aula` INT NOT NULL,
  `num_bilhetes` INT NULL,
  `preco_bilhete` FLOAT NOT NULL,
  `data_ini` DATETIME NOT NULL,
  `data_fim` DATETIME NOT NULL,
  `modalidade` VARCHAR(36) NOT NULL,
  `instrutor` VARCHAR(9) NOT NULL,
  `espaco` INT NOT NULL,
  PRIMARY KEY (`cod_aula`),
  INDEX `fk_AULA_MODALIDADE1_idx` (`modalidade` ASC) VISIBLE,
  INDEX `fk_AULA_INSTRUTOR1_idx` (`instrutor` ASC) VISIBLE,
  INDEX `fk_AULA_ESPACOS1_idx` (`espaco` ASC) VISIBLE,
  CONSTRAINT `fk_AULA_MODALIDADE1`
    FOREIGN KEY (`modalidade`)
    REFERENCES `SportsManager`.`MODALIDADE` (`designacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_AULA_INSTRUTOR1`
    FOREIGN KEY (`instrutor`)
    REFERENCES `SportsManager`.`INSTRUTOR` (`nif`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_AULA_ESPACOS1`
    FOREIGN KEY (`espaco`)
    REFERENCES `SportsManager`.`ESPACOS` (`cod_espaco`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportsManager`.`ALUGA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`ALUGA` (
  `ESPACOS_cod_espaco` INT NOT NULL,
  `UTILIZADOR_nif` VARCHAR(9) NOT NULL,
  `data_ini` DATETIME NOT NULL,
  `data_fim` DATETIME NOT NULL,
  PRIMARY KEY (`ESPACOS_cod_espaco`, `UTILIZADOR_nif`),
  INDEX `fk_ESPACOS_has_UTILIZADOR_UTILIZADOR1_idx` (`UTILIZADOR_nif` ASC) VISIBLE,
  INDEX `fk_ESPACOS_has_UTILIZADOR_ESPACOS1_idx` (`ESPACOS_cod_espaco` ASC) VISIBLE,
  CONSTRAINT `fk_ESPACOS_has_UTILIZADOR_ESPACOS1`
    FOREIGN KEY (`ESPACOS_cod_espaco`)
    REFERENCES `SportsManager`.`ESPACOS` (`cod_espaco`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ESPACOS_has_UTILIZADOR_UTILIZADOR1`
    FOREIGN KEY (`UTILIZADOR_nif`)
    REFERENCES `SportsManager`.`UTILIZADOR` (`nif`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SportsManager`.`FREQUENTA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SportsManager`.`FREQUENTA` (
  `UTILIZADOR_nif` VARCHAR(9) NOT NULL,
  `AULA_cod_aula` INT NOT NULL,
  PRIMARY KEY (`UTILIZADOR_nif`, `AULA_cod_aula`),
  INDEX `fk_UTILIZADOR_has_AULA_AULA1_idx` (`AULA_cod_aula` ASC) VISIBLE,
  INDEX `fk_UTILIZADOR_has_AULA_UTILIZADOR1_idx` (`UTILIZADOR_nif` ASC) VISIBLE,
  CONSTRAINT `fk_UTILIZADOR_has_AULA_UTILIZADOR1`
    FOREIGN KEY (`UTILIZADOR_nif`)
    REFERENCES `SportsManager`.`UTILIZADOR` (`nif`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_UTILIZADOR_has_AULA_AULA1`
    FOREIGN KEY (`AULA_cod_aula`)
    REFERENCES `SportsManager`.`AULA` (`cod_aula`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
