from flask import Flask, jsonify, request
from flask_jwt_extended import (
    JWTManager, 
    jwt_required, 
    create_access_token,
    get_jwt_identity
)

USERS = [
    { 
        "username": "jim",
        "password": "sogood" 
    },
    { 
        "username": "hannah",
        "password": "decent"
    },
]

app = Flask(__name__)

# Setup the Flask-JWT-Extended extension
app.config['JWT_SECRET_KEY'] = 'FsUbFd6ANLM6LyeMl3W0QnmhED4FP7ZXm6zyb9DcRfMg3CiVFY_Itddn4u_2hQgimRZt58hIVTIc_m919XajUg2u3JJRsGW_qv7FlB-Rtvm1yMTXfT0lfn91feuuzXjbx0Q7eEiHxlJIsAnkgE5ZaXvIDKhhesEBZNeU9LRitFoUKbhtB-jS7xWZ2BWPNloO4svA9tHD1FsZ8ovbzDoUmXvqtLJCz63k7UcBYY7qMlJJ4PrrkQKa5X6zR78utcxBTmAf2ocq4G0-1DOvyFTc7QoV29ozadFNOPGM6ulttePR0Dkr85S1LlMssjk6xon8Yytm_EvU35uy6ZsYseicOA'
jwt = JWTManager(app)


# Provide a method to create access tokens. The create_access_token()
# function is used to actually generate the token, and you can return
# it to the caller however you choose.
@app.route('/api/auth', methods=['POST'])
def login():
    if not request.is_json:
        return jsonify({"msg": "Missing JSON in request"}), 400

    username = request.json.get('username', None)
    password = request.json.get('password', None)
    if not username:
        return jsonify({"msg": "Missing username parameter"}), 400
    if not password:
        return jsonify({"msg": "Missing password parameter"}), 400

    for user in USERS:
        if username == user['username'] and password == user['password']:
            break
    else:
        return jsonify({"msg": "Bad username or password"}), 401

    # Identity can be any data that is json serializable
    access_token = create_access_token(identity=username)
    return jsonify(access_token=access_token), 200
