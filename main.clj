(ns main
  (:import [System.IO File]))


(defn- prep-command [command]
  (if (and (.StartsWith command "(")
           (.EndsWith command ")"))
    command
    (format "(%s)" command)))

(defn exec-command [^String command]
  (binding [*ns* (find-ns 'user)]
    (-> command
        (prep-command)
        (read-string)
        (eval))))

(defn list-commands []
  (-> 'user
      (ns-publics)
      (keys)))

(defn load-custom [xel-home]
  (let [xel-config (str xel-home "user.clj")]
    (if (File/Exists xel-config)
      (load-file xel-config)
      (load-file "user.clj"))))