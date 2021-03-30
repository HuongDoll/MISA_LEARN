<template>
  <div>
    <div class="dialog" id="dialog" @click="closedialog()"></div>
    <form class="dialog-child" id="dialog-child">
      
      <div class="title">
        <div>THÔNG TIN KHÁCH HÀNG</div>
        <div class="tab-close">
        <button @click="closedialog()">
          <i class="fas fa-times fa-5x" id="close-dialog"></i>
        </button>
        </div>
      </div>
      <div class="parent-content">
        <div class="content-dialog">
          <div class="content-left wight-1-3">
            <img
              src="../../../assets/content/image/default-avatar.jpg"
              class="image-avatar"
            />
            <div>Vui lòng chọn ảnh có định dạng</div>
            <b>.jpg, .jpeg, .png, .gif.</b>
          </div>
          <div class="content-right wight-2-3">
            <div>
              <div class="group-input">
                <div class="group wight-1-2">
                  <label>Mã khách hàng <span class="text-red">(*)</span></label>
                  <input
                    v-bind:class="{ warning: !validates.CustomerCode }"
                    type="text"
                    id="CustomerCode"
                    v-model="customer.customerCode"
                  />
                </div>
                <div class="group wight-1-2">
                  <label>Họ và tên <span class="text-red">(*)</span></label>
                  <input
                    v-bind:class="{ warning: !validates.FullName }"
                    type="text"
                    id="FullName"
                    v-model="customer.fullName"
                  />
                </div>
              </div>
              <div class="group-input">
                <div class="group wight-1-2">
                  <label>Mã thẻ thành viên</label>
                  <input
                    type="text"
                    id="MemberCardCode"
                    v-model="customer.memberCardCode"
                  />
                </div>
                <div class="group wight-1-2">
                  <label>Nhóm khách hàng</label>
                  <select
                    id="CustomerGroupName"
                    v-model="customer.customerGroupName"
                  >
                    <option value="Nhóm khách hàng MISA" selected>
                      Nhóm khách hàng MISA
                    </option>
                    <option value="Khách vip">Khách vip</option>
                  </select>
                </div>
              </div>

              <div class="group-input">
                <div class="group wight-1-2">
                  <label>Ngày sinh</label>
                  <input
                    type="date"
                    id="DateOfBirth"
                    name="DateOfBirth"
                    v-model="customer.dateOfBirth"
                  />
                  <!-- <input type="date" id="DateOfBirth" name="DateOfBirth" value="2021-03-09"> -->
                </div>
                <div class="group-sex wight-1-2">
                  <div>Giới tính</div>
                  <div>
                    <span class="radio-sex wight-1-3">
                    <input
                      type="radio"
                      id="male"
                      name="Gender"
                      :value="1"
                      v-model="customer.gender"
                    />
                    <label for="male">Nam</label>
                  </span>
                  <span class="radio-sex wight-1-3">
                    <input
                      type="radio"
                      id="female"
                      name="Gender"
                      :value="2"
                      v-model="customer.gender"
                    />
                    <label for="female">Nữ</label>
                  </span>
                  <span class="radio-sex wight-1-3">
                    <input
                      type="radio"
                      id="other"
                      name="Gender"
                      :value="0"
                      checked
                      v-model="customer.gender"
                    />
                    <label for="other">Khác</label>
                  </span>
                  </div>
                  
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="content-down">
          <div class="group-input">
            <div class="group wight-2-3">
              <label>Email</label>
              <input
                v-bind:class="{ warning: !validates.Email }"
                type="text"
                placeholder="example@domain.com"
                id="Email"
                v-model="customer.email"
              />
            </div>
            <div class="group wight-1-3">
              <label>Số điện thoại <span class="text-red">(*)</span></label>
              <input
                v-bind:class="{ warning: !validates.PhoneNumber }"
                type="text"
                id="PhoneNumber"
                v-model="customer.phoneNumber"
              />
            </div>
          </div>
          <div class="group-input">
            <div class="group wight-2-3">
              <label>Tên công ty</label>
              <input
                type="text"
                id="CompanyName"
                v-model="customer.companyName"
              />
            </div>
            <div class="group wight-1-3">
              <label>Mã số thuế</label>
              <input
                type="text"
                placeholder="Mã số thuế của công ty"
                id="CompanyTaxCode"
                v-model="customer.companyTaxCode"
              />
            </div>
          </div>
          <div class="group-input">
            <div class="group wight-full">
              <label>Địa chỉ</label>
              <input type="text" id="Address" v-model="customer.address" />
            </div>
          </div>
        </div>
      </div>

      <div class="footer">
        <button
          type="button"
          class="button-delete"
          id="button-delete"
          @click="closedialog()"
        >
          HỦY
        </button>
        <button
          type="button"
          class="button-save"
          id="button-save"
          @click="save()"
        >
          <span><i class="far fa-save"></i></span>
          <span>LƯU</span>
        </button>
      </div>
    </form>
  </div>
</template>
<script>
export default {
  name: "CustomerDetail",
  props: {
    msg: String,
  },
  data() {
    return {
      customer: {
        address: "",
        companyName: "",
        companyTaxCode: "",
        customerCode: "",
        customerGroupName: "Nhóm khách hàng MISA",
        dateOfBirth: null,
        email: "",
        fullName: "",
        gender: 0,
        memberCardCode: "",
        phoneNumber: "",
      },
      validates: {
        CustomerCode: true,
        FullName: true,
        Email: true,
        PhoneNumber: true,
      },
    };
  },
  methods: {
    closedialog() {
      this.$emit("closedialog");
      this.customer.address = "";
      this.customer.companyName = "";
      this.customer.companyTaxCode = "";
      this.customer.customerGroupName = "Nhóm khách hàng MISA";
      this.customer.email = "";
      this.customer.fullName = "";
      this.customer.gender = 0;
      this.customer.memberCardCode = "";
      this.customer.phoneNumber = "";
      this.customer.dateOfBirth = null;
      this.customer.customerCode = "";
      this.validates.CustomerCode = true;
      this.validates.FullName = true;
      this.validates.Email = true;
      this.validates.PhoneNumber = true;
    },
    save() {
      var vm = this;
      console.log(vm.customer);
      if (vm.validate()) {
        if (vm.msg == "post") {
            this.$store.dispatch('insertCustomer', vm.customer);
            this.closedialog();
        }
      }
    },
    validate() {
      var phonenumber = /^\d{10}$/;
      var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
      if (this.customer.customerCode == "") {
        this.validates.CustomerCode = false;
        return false;
      } else {
        this.validates.CustomerCode = true;
      }
      if (this.customer.fullName == "") {
        this.validates.FullName = false;
        return false;
      } else {
        this.validates.FullName = true;
      }
      if (
        this.customer.phoneNumber == "" ||
        !this.customer.phoneNumber.match(phonenumber)
      ) {
        this.validates.PhoneNumber = false;
        return false;
      } else {
        this.validates.PhoneNumber = true;
      }
      if (!this.customer.email.match(mailformat) && this.customer.email != "") {
        this.validates.Email = false;
        return false;
      } else {
        this.validates.Email = true;
      }
      return true;
    },
  },
};
</script>

<style scoped>
/* css dialog sửa xóa khách hàng */
.warning {
  border-color: red !important ;
}
.mini-dialog {
  width: 100%;
  height: 100vh;
  position: fixed;
  left: 0px;
  top: 0px;
}
.mini-select {
  background-color: white;
  position: absolute;
  top: calc(50% - 400px);
  left: calc(50% - 400px);
  padding: 8px;
  border-radius: 10px;
  border-top-right-radius: 0px;
  border: 1px solid gray;
  box-shadow: 5px 10px 8px #888888;
}
.mini-select button {
  margin: 4px;
  width: 30px;
  height: 30px;
}
.mini-select button i {
  font-size: 16px;
  color: #bbbbbb;
}
.mini-select button i:hover {
  color: black;
}
/* css dialog form thông tin khách hàng */
.dialog {
  background-color: rgb(71, 69, 69, 0.6);
  width: 100%;
  height: 100vh;
  position: fixed;
  left: 0px;
  top: 0px;
}
.dialog-child {
  background-color: white;
  max-width: 800px;
  max-height: 800px;
  position: absolute;
  top: calc(50% - 400px);
  left: calc(50% - 400px);
}

.tab-close {
  position: absolute;
  top: 0px;
  right: 0px;
}
.tab-close button{
  background-color: #ffffff;
  outline: none;
  border: none;
  width: 32px;
  height: 32px;
}

.title {
  padding: 20px;
  padding-left: 24px;
  font-size: 24px;
  font-weight: bold;
  display: flex;
}
.parent-content {
  padding: 8px;
  padding-right: 24px;
  padding-left: 24px;
}
.content-dialog {
  display: flex;
  padding: 0px;
}
.content-left {
  text-align: center;
  padding-left: 0px;
  padding-top: 8px;
}
.content-left img {
  width: 75%;
  border-radius: 50%;
  border: 1px solid #bbbbbb;
}
.content-name {
  padding-top: 20px;
}
.group-input {
  display: flex;
  margin-bottom: 8px;
}
.group-input .group {
  padding: 8px;
}
.group input {
  width: calc(100% - 20px);
  height: 40px;
  border-radius: 4px;
  border: 1px solid #bbbbbb;
  outline: none;
  padding-left: 16px;
  font-size: 11px;
}
.group input[type = "date"]{
  width: calc(100% - 28px);
}
.group input:focus{
  border: 1px solid #019160;
}
.group select {
  width: calc(100% - 0px);
  height: 44px;
  border-radius: 5px;
  border: 1px solid #bbbbbb;
  outline: none;
}
.group-input .group label {
  padding-bottom: 4px;
  display: block;
}
.radio-sex {
  vertical-align: middle;
  margin-right: 8px;
}
.radio-sex span {
  vertical-align: middle;
}

input[type="radio"] {
  display: none;
}

input[type="radio"]+label:before {
  content: "";
  /* create custom radiobutton appearance */
  display: flex;
  width: 12px;
  height: 12px;
  padding: 4px;
  margin-right: 3px;
  /* background-color only for content */
  background-clip: content-box;
  border: 1px solid #019160;
  background-color: #ffffff;
  border-radius: 50%;
}

/* appearance for checked radiobutton */
input[type="radio"]:checked + label:before {
  background-color: #019160;
}

/* optional styles, I'm using this for centering radiobuttons */
label {
  display: flex;
  padding-left: 4px;
  align-items: center;
}

.group-sex div {
  padding-bottom: 8px;
  padding-top: 8px;
  width: 100%;
  display: flex;
}

.content-down {
  padding: 0px;
  margin-left: 0px;
}
.footer {
  padding-right: 20px;
  text-align: right;
  vertical-align: middle;
  background-color: #E9EBEE;
  height: 60px;
}
.button-delete {
  height: 40px;
  background: none;
  border: none;
  outline: none;
  font-size: 13px;
  padding-left: 16px;
  padding-right: 16px;
  margin-right: 16px;
  margin-top: 10px;
  vertical-align: middle;
}
.button-delete:hover{
  border: 1px solid #bbbbbb;
}
.button-save {
  height: 40px;
  margin-top: 10px;
  border: none;
  border-radius: 4px;
  vertical-align: middle;
  background-color: #019160;
  outline: none;
  font-size: 13px;
  color: #ffffff;
  padding-left: 8px;
  padding-right: 16px;
}
.button-save:hover{
  background-color: #2FBE8E;
}
.button-save span {
  vertical-align: middle;
  margin-left: 8px;
}
.button-save i {
  font-size: 25px;
}
/* định dang độ rộng */
.wight-1-3 {
  width: 33.333333333333333333333333333333333%;
}
.wight-1-2 {
  width: 50%;
}
.wight-2-3 {
  width: 66.6666666666666666666666666666666667%;
}
.wight-full {
  width: 100%;
}
/* important */
.text-red {
  color: red;
}
</style>