#!/usr/bin/env php
<?php

require_once __DIR__.'/helper.php';
use \Dropbox as dbx;

/* @var dbx\Client $client */
/* @var string $dropboxPath */
list($client, $dropboxPath) = parseArgs("direct-link", $argv, array(
        array("dropbox-path", "https://www.dropbox.com/s/a2vflzmepe61wgl/curriculumGorkaMunoz.pdf?dl=0"),
    ));

$pathError = dbx\Path::findError($dropboxPath);
if ($pathError !== null) {
    fwrite(STDERR, "Invalid <dropbox-path>: $pathError\n");
    die;
}

$link = $client->createTemporaryDirectLink($dropboxPath);

print_r($link);

