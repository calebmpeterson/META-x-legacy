(ns main
  (:require [functions :refer :all] :reload-all))

(System.Diagnostics.Trace/WriteLine "reload main.clj")


(defn- prep-command [command]
  (if (and (.StartsWith command "(")
           (.EndsWith command ")"))
    command
    (format "(%s)" command)))

(defn exec-command [^String command]
  (binding [*ns* (find-ns 'functions)]
    (-> command
        (prep-command)
        (read-string)
        (eval))))

(defn list-commands []
  (-> 'functions
      (ns-publics)
      (keys)))
