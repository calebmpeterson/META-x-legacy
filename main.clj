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



(defn- not-in-clojure-core [v]
  (not (.StartsWith (str v) "#'clojure.core")))
(defn- trim-ns-from-var [v]
  (subs v (inc (.LastIndexOf v \/))))

(defn list-commands []
  (->> 'user
      (ns-refers)
      (vals)
      (filter not-in-clojure-core)
      (map str)
      (map trim-ns-from-var)))


(defn load-custom [meta-x-home]
  (let [meta-x-config (str meta-x-home "user.clj")]
    (if (File/Exists meta-x-config)
      (load-file meta-x-config)
      (load-file "user.clj"))))
